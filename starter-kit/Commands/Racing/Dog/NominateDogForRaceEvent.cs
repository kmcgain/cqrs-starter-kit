using System;

namespace Commands.Racing.Dog
{
    public class NominateDogForRaceEvent
    {
        public Guid DogId { get; set; }

        public Guid RaceEventId { get; set; }

        // A race condition
        public bool DogsOnly { get; set; }

        public bool BitchesOnly { get; set; }
    }
}