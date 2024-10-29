using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Citizen : Person
    {
        public override string Character => "C";

        public Citizen() : base()
        {
            
            
            Inventory.Add(new Item("Nycklar"));
            Inventory.Add(new Item("Mobiltelefon"));
            Inventory.Add(new Item("Pengar"));
            Inventory.Add(new Item("Klocka"));
            XLocation = RandomStartPosX();
            YLocation = RandomStartPosY();
            SetRandomDirection();
            string name = GenerateRandomName();
            Name = name;
            

            

        }
    }
}
