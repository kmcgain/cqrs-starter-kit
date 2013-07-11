using System;
using System.Collections.Generic;
using Commands.Racing.Meeting;
using Edument.CQRS;
using Racing.Dog.CommandHandle;

namespace Racing.Meeting.CommandHandle
{
    public class NominateDogForMeetingHandler : IHandleCommand<NominateDogForMeeting, MeetingAggregate>
    {
        public IEnumerable<Event> Handle(Func<Guid, MeetingAggregate> al, NominateDogForMeeting c)
        {
            // Meeting validation?

            yield return new MeetingReceivedNomination(c.MeetingId, c.DogId);
        }
    }
}