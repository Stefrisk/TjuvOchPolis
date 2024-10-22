using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Robber : Person
    {
        public Robber(int x, int y) : base(x, y) 
        {
            Inventory = new List<Item>();

            SetRandomDirection();
            string name = GenerateRandomName();
            Name = name;
        }
    }
}
