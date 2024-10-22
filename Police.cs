using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Police: Person
    {
        public Police(int x,int y) : base(x,y) 
        {
            Inventory = new List<Item>();
            RandomStartPosX();
            RandomStartPosY();
            SetRandomDirection();
            string name = GenerateRandomName();
            Name = name;
        }

    }
}
