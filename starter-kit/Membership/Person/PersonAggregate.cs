using System;
using System.Collections.Generic;
using System.Linq;
using Commands.Racing.Dog;
using Edument.CQRS;
using Events.Membership;
using Membership.Person.CommandHandle;

namespace Membership.Person
{
    public partial class PersonAggregate : Aggregate
    {
        private readonly MessageDispatcher messageDispatcher;

        public PersonAggregate(MessageDispatcher messageDispatcher)
        {
            this.messageDispatcher = messageDispatcher;
        }

        public string Name { get; private set; }

        private ICollection<KenneledDog> kennelledDogs { get; set; }
    }

    // ValueObject

    public partial class PersonAggregate : IApplyEvent<PersonCreated>, IApplyEvent<DogKennelled>
    {
        public void Apply(PersonCreated e)
        {
            this.Name = e.Name;
        }

        public bool IsARegisteredTrainer()
        {
            return true;
        }

        public bool HasKennelledDog(Guid dogId)
        {
            return kennelledDogs.Any(kd => kd.DogId == dogId && kd.IsKennelled);
        }

        public void Apply(DogKennelled e)
        {
            this.kennelledDogs.Add(new KenneledDog(){DogId = e.DogId, IsKennelled = true, KennelledOn = e.KennelDate});

            messageDispatcher.SendCommand(new AddTrainerToDog(){DogId = e.DogId, PersonId = this.Id});
        }
    }
}
