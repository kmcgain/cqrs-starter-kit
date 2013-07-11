using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Person.CommandHandle
{
    public class ChangePersonName
    {
        public Guid PersonId { get; set; }

        public string Name { get; set; }
    }
}
