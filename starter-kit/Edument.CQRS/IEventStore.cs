using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Edument.CQRS
{
    public interface IEventStore
    {
        IEnumerable<Event> LoadEventsFor<TAggregate>(Guid id);
        void SaveEventsFor<TAggregate>(Guid? id, int eventsLoaded, IEnumerable<Event> newEvents);
    }
}
