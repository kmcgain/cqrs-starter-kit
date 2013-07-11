using System;
using Edument.CQRS;

namespace Events.Membership
{
    public class PersonChangedName : AggregateEvent
    {
        public PersonChangedName(Guid aggregateId) : base(aggregateId)
        {
        }

        public string Name { get; set; }
    }
}