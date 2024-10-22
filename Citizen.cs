using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Citizen : Person
    {
        
        public Citizen(int x, int y) : base(x,y)
        {
            
            Inventory.Add(new Item("Nycklar"));
            Inventory.Add(new Item("Mobiltelefon"));
            Inventory.Add(new Item("Pengar"));
            Inventory.Add(new Item("Klocka"));
            RandomStartPosX();
            RandomStartPosY();
            SetRandomDirection();
            string name = GenerateRandomName();
            Name = name;

        }
    }
}
