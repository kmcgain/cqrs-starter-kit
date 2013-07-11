using System;
using Edument.CQRS;

namespace Events.Racing
{
    public class DogRegistered : AggregateEvent
    {
        public DogRegistered() : base(Guid.NewGuid())
        {
        }

        public string Name { get; set; }

        public string Earbrand { get; set; }
    }
}