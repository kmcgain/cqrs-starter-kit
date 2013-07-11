using System;
using Edument.CQRS;

namespace Events.Racing
{
    public class TrainerAddedToDog : AggregateEvent
    {
        public TrainerAddedToDog(Guid aggregateId) : base(aggregateId)
        {
        }

        public Guid TrainerId { get; set; }
    }
}