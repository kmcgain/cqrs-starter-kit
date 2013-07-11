using System;
using Edument.CQRS;

namespace Events.Racing
{
    public class MeetingCreated : AggregateEvent
    {
        public MeetingCreated() : base(Guid.NewGuid())
        {
        }

        public DateTime MeetingDate { get; set; }
    }
}