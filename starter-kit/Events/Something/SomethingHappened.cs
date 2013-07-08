using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edument.CQRS;

namespace Events.Something
{
    public class SomethingHappened : Event
    {
        public Guid Id;
        public string What;
    }
}
