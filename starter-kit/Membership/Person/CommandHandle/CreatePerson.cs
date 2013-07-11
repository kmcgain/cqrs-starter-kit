using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Person.CommandHandle
{
    public class CreatePerson
    {
        public string Name { get; set; }

        public CreatePerson(string name)
        {
            Name = name;
        }
    }
}
