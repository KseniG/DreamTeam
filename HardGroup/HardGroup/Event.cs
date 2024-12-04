using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardGroup
{
    public class Event
    {
        public string Name { get; set; }
        public Action Action { get; set; }

        public Event(string name, Action action)
        {
            Name = name;
            Action = action;
        }
    }
}
