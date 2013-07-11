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
    public class AddTrainerToDogHandler : IHandleCommand<AddTrainerToDog, DogAggregate>
    {
        public IEnumerable<Event> Handle(Func<Guid, DogAggregate> al, AddTrainerToDog c)
        {
            var dogAggregate = al(c.DogId);

            if (dogAggregate.HasATrainer())
            {
                throw new DogAlreadyHasATrainerException();
            }

            yield return new TrainerAddedToDog(c.DogId) { TrainerId = c.PersonId };
        }
    }
}
