using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;
using Events.Membership;

namespace Membership.Person.CommandHandle
{
    public class CreatePersonHandler : IHandleCommand<CreatePerson, PersonAggregate>
    {
        public IEnumerable<Event> Handle(Func<Guid, PersonAggregate> al, CreatePerson c)
        {
            if (string.IsNullOrEmpty(c.Name))
            {
                throw new PersonNameInvalidExcpetion();
            }

            yield return new PersonCreated(c.Name);
        }
    }
}
