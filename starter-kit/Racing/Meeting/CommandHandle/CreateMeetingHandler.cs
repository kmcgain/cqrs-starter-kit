using System;
using System.Collections.Generic;
using Edument.CQRS;
using Events.Racing;

namespace Racing.Meeting.CommandHandle
{
    public class CreateMeetingHandler : IHandleCommand<CreateMeeting, MeetingAggregate>
    {
        public IEnumerable<Event> Handle(Func<Guid, MeetingAggregate> al, CreateMeeting c)
        {
            if (c.MeetingDate == null)
            {
                throw new ArgumentException();
            }

            yield return new MeetingCreated() { MeetingDate = c.MeetingDate};
        }
    }
}