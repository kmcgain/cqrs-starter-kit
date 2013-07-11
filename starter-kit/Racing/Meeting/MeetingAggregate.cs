using System;
using System.Collections.Generic;
using Commands.Racing.Dog;
using Edument.CQRS;
using Events.Racing;
using Racing.Dog.CommandHandle;

namespace Racing.Meeting
{
    public class MeetingAggregate : Aggregate, IApplyEvent<MeetingCreated>, IApplyEvent<MeetingReceivedNomination>
    {
        private readonly MessageDispatcher messageDispatcher;

        public MeetingAggregate(MessageDispatcher messageDispatcher)
        {
            this.messageDispatcher = messageDispatcher;
        }

        public void Apply(MeetingCreated e)
        {
            MeetingDate = e.MeetingDate;
        }

        public DateTime MeetingDate { get; set; }

        public ICollection<RaceEvent> RaceEvents { get; private set; }

        public ICollection<Guid> Nominations { get; private set; } 
        
        public void Apply(MeetingReceivedNomination e)
        {
            Nominations.Add(e.DogId);

            foreach (var raceEvent in RaceEvents)
            {
                try
                {
                    messageDispatcher.SendCommand(new NominateDogForRaceEvent() { DogId = e.DogId, RaceEventId = raceEvent.Id, DogsOnly = raceEvent.DogsOnly, BitchesOnly = raceEvent.BitchesOnly });
                }
                catch (DogNotEligibleForRaceEventException exception)
                {
                    // Perhaps a client notification command to say their nom was not successful?    
                }
            }
        }
    }
}