using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace Edument.CQRS
{
    public class GetEventStore : IEventStore
    {
        private const string aggregateStreamName = "Aggregate";

        private readonly EventStoreConnection esConnection;        

        public GetEventStore(EventStoreConnection esConnection)
        {
            this.esConnection = esConnection;            
        }

        public IEnumerable<Event> LoadEventsFor<TAggregate>(Guid id)
        {
            var streamName = GetStreamName<TAggregate>(id);

            var results = new List<Event>();
            var moreResults = true;
            while (moreResults)
            {
                var eventsForAggregate = esConnection.ReadStreamEventsForward(streamName, 0, 1000, false);
                if (eventsForAggregate.Status != SliceReadStatus.Success)
                {
                    return new List<Event>();
                }

                var events = eventsForAggregate.Events
                    .Where(_ => _.Event.EventType != "$stream-created-implicit")
                    .Select(_ =>
                                                                  {
                                                                      var value = BytesToString.ToString(_.Event.Data);
                                                                      var eventType = JsonConvert.DeserializeObject<Type>(BytesToString.ToString(_.Event.Metadata));

//                                                                      var methodInfo = typeof (JsonConvert).GetMethods()
//                                                                          .Where(info => info.Name == "DeserializeObject")                                                                          
//                                                                          .Where(info => info.IsGenericMethod)
//                                                                          .Where(info => info.IsStatic)
//                                                                          .Where(info => info.GetParameters().Length == 1 && info.GetParameters().Single().ParameterType == typeof(String))
//                                                                          .Single();
//
//                                                                      return (Event) methodInfo
//                                                                                         .MakeGenericMethod(Type.GetType(type))
//                                                                                         .Invoke(null, new[] {value});
                                                                      return (Event)JsonConvert.DeserializeObject(value, eventType);
                                                                  });
                results.AddRange(events.ToList());
                moreResults = !eventsForAggregate.IsEndOfStream;
            }

            return results;
        }

        public string GetStreamName<TAggregate>(Guid id)
        {
            return string.Format("{0}:{1}:{2}", aggregateStreamName, typeof(TAggregate).FullName, id);
        }

        public void SaveEventsFor<TAggregate>(Guid? id, int eventsLoaded, IEnumerable<Event> newEvents)
        {
            if (!id.HasValue)
            {
                throw new ArgumentException("Why no id?");
            }
            var events = new List<EventData>();
            foreach (var newEvent in newEvents)
            {
                var eventBytes = BytesToString.ToBytes(JsonConvert.SerializeObject(newEvent, new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.All}));                
                var typeMeta = BytesToString.ToBytes(JsonConvert.SerializeObject(newEvent.GetType(), new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.All}));
                events.Add(new EventData(Guid.NewGuid(), aggregateStreamName, true, eventBytes, typeMeta));
            }
            esConnection.AppendToStream(GetStreamName<TAggregate>(id.Value), eventsLoaded, events);
        }
    }
}
