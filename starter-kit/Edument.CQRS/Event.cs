using System;

namespace Edument.CQRS
{
    public interface Event
    {
        Guid AggregateId { get; }
    }

    public class AggregateEvent : Event
    {
        public AggregateEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public Guid AggregateId { get; private set; }
    }
}