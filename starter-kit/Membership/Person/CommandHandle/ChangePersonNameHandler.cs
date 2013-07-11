using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;
using Events.Membership;

namespace Membership.Person.CommandHandle
{
    public class ChangePersonNameHandler : IHandleCommand<ChangePersonName, PersonAggregate>
    {
        public IEnumerable<Event> Handle(Func<Guid, PersonAggregate> al, ChangePersonName c)
        {
            if (string.IsNullOrEmpty(c.Name))
            {
                throw new PersonNameInvalidExcpetion();
            }

            var personAggregate = al(c.PersonId);
            
            if (personAggregate.Name == c.Name)
            {
                throw new PersonNameSameException();
            }

            yield return new PersonChangedName(c.PersonId){ Name = c.Name };
        }
    }
}
