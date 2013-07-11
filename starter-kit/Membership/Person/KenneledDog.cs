using System;

namespace Membership.Person
{
    public class KenneledDog
    {
        public Guid DogId { get; set; }

        public DateTime KennelledOn { get; set; }

        public bool IsKennelled { get; set; }
    }
}