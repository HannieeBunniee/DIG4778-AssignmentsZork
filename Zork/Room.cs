using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork
{
    public class Room
    {
        public override string ToString() => Name; // => is equivalent to typing { return Name; }

        public string Name { get; }

        public string Description { get; set; } 

        public Room(string name, string description = "")
        {
            Name = name;
            Description = description;
        }

    }
}
