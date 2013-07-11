using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commands.Racing.Dog;
using Edument.CQRS;

namespace Racing.Dog.CommandHandle
{
    public class MeetingReceivedNomination : AggregateEvent
    {
        public MeetingReceivedNomination(Guid meetingId, Guid dogId) : base(meetingId)
        {
            DogId = dogId;
        }

        public Guid DogId { get; set; }
    }
}
