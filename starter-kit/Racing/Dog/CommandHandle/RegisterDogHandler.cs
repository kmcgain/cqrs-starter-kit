using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;
using Events.Racing;

namespace Racing.Dog.CommandHandle
{
    public class RegisterDogHandler : IHandleCommand<RegisterDog, DogAggregate>
    {
        public IEnumerable<Event> Handle(Func<Guid, DogAggregate> al, RegisterDog c)
        {
            yield return new DogRegistered() {Name = c.DogName, Earbrand = c.Earbrand };
        }
    }
}
