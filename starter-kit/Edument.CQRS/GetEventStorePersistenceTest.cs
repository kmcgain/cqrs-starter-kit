using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using EventStore.ClientAPI;
using NUnit.Framework;

namespace Edument.CQRS
{
    [TestFixture]
    public class GetEventStorePersistenceTest
    {
        [Test]
        public void ItShouldWriteEventsProperly()
        {            
            var eventStoreConnection = EventStoreConnection.Create();
            eventStoreConnection.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1113));

            var getEventStore = new GetEventStore(eventStoreConnection);
            

            var testAggregate = new TestAggregate() {Id = Guid.NewGuid()};            
            getEventStore.SaveEventsFor<TestAggregate>(testAggregate.Id, ExpectedVersion.Any, new List<Event>(){new Tested(){Prop = 1}});

            var readEvents = getEventStore.LoadEventsFor<TestAggregate>(testAggregate.Id.Value);

            Assert.AreEqual(1, readEvents.Count());

            var resolvedEvent = readEvents.First();
            Assert.AreEqual(1, ((Tested) resolvedEvent).Prop);
        }

        public class TestAggregate : Aggregate
        {
            
        }

        public class Tested : Event
        {
            public virtual int Prop { get; set; }
        }
    }

    public interface Event
    {
    }
}
