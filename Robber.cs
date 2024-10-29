using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Robber : Person
    {
        public override string Character => "R";

        public Robber() : base() 
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
