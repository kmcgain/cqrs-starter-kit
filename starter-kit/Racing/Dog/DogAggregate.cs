using System;
using System.Collections.Generic;
using Edument.CQRS;
using Events.Racing;
using Racing.Dog.CommandHandle;

namespace Racing.Dog
{
    public class DogAggregate : Aggregate, IApplyEvent<TrainerAddedToDog>, IApplyEvent<DogNominatedForRaceEvent>
    {
        private Guid? currentTrainerId;
        private bool isDog;
        private bool isBitch;
        private ICollection<Guid> upcomingEvents;

        public bool HasATrainer()
        {
            return currentTrainerId != null;
        }

        public void Apply(TrainerAddedToDog e)
        {
            currentTrainerId = e.TrainerId;
        }

        public bool IsDog()
        {
            return isDog;
        }

        public bool IsBitch()
        {
            return isBitch;
        }

        public void Apply(DogNominatedForRaceEvent e)
        {
            upcomingEvents.Add(e.RaceEventId);
        }
    }
}
