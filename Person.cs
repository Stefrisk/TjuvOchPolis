using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Person: Town
    {
        internal string Name { get; set; }
        internal string Direction { get; set; }
        internal string[] Inventory { get; set; }
        internal int Y {  get; set; }
        internal int X { get; set; }

    }
}
