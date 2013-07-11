using Edument.CQRS;

namespace Racing.Meeting
{
    public class RaceEvent : Entity
    {
        public bool DogsOnly { get; set; }

        public bool BitchesOnly { get; set; }
    }
}