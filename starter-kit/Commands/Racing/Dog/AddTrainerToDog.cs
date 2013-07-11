using System;

namespace Commands.Racing.Dog
{
    public class AddTrainerToDog
    {
        public Guid DogId { get; set; }

        public Guid PersonId { get; set; }
    }
}