using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commands.Racing.Dog;
using Edument.CQRS;
using Events.Racing;

namespace Racing.Dog.CommandHandle
{
    public class NominateDogForRaceEventHandler : IHandleCommand<NominateDogForRaceEvent, DogAggregate>
    {
        public IEnumerable<Event> Handle(Func<Guid, DogAggregate> al, NominateDogForRaceEvent c)
        {
            var dogAggregate = al(c.DogId);

            if (c.DogsOnly && !dogAggregate.IsDog()
                || c.BitchesOnly && !dogAggregate.IsBitch())
            {
                throw new DogNotEligibleForRaceEventException();
            }

            yield return new DogNominatedForRaceEvent(c.DogId) { RaceEventId = c.RaceEventId };
        }
    }
}
