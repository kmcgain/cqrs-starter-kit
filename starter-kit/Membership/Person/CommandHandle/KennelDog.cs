using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;

namespace Membership.Person.CommandHandle
{
    public class KennelDog
    {
        public Guid PersonId { get; set; }

        public Guid DogId { get; set; }
    }

    public class KennelDogHandler : IHandleCommand<KennelDog, PersonAggregate>
    {
        public IEnumerable<Event> Handle(Func<Guid, PersonAggregate> al, KennelDog c)
        {
            var personAggregate = al(c.PersonId);

            if (!personAggregate.IsARegisteredTrainer())
            {
                throw new PersonNotRegisteredException();
            }

            if (personAggregate.HasKennelledDog(c.DogId))
            {
                throw new DogAlreadyKenelledException();
            }

            yield return new DogKennelled(c.PersonId) {DogId = c.DogId, KennelDate = DateTime.Now};
        }
    }

    public class DogKennelled : AggregateEvent
    {
        public DogKennelled(Guid aggregateId) : base(aggregateId)
        {
        }

        public Guid DogId { get; set; }

        public DateTime KennelDate { get; set; }
    }
}
