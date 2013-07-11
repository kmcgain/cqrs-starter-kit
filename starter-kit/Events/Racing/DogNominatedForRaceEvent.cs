using System;
using Edument.CQRS;

namespace Events.Racing
{
    public class DogNominatedForRaceEvent : AggregateEvent
    {
        public DogNominatedForRaceEvent(Guid aggregateId) : base(aggregateId)
        {
        }

        public Guid RaceEventId { get; set; }
    }
}