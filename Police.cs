using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Police: Person
    {
        public Police() : base() 
        {
            Inventory = new List<Item>();
            XLocation = RandomStartPosX();
            YLocation = RandomStartPosY();
            SetRandomDirection();
            string name = GenerateRandomName();
            Name = name;
        }

    }
}
