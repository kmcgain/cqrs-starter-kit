using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edument.CQRS;

namespace Events.Membership
{
    public class PersonCreated : AggregateEvent
    {
        public string Name { get; set; }

        public PersonCreated(string name) : base(Guid.NewGuid())
        {
            Name = name;
        }
    }
}
