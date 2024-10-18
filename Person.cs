using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Person
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int XDirection { get; set; }
        public int YDirection { get; set; }
        public List<Item> Inventory { get; set; }

        public Person(int x, int y)
        {
            X = x;
            Y = y;
            Inventory = new List<Item>();
            SetRandomDirection();
        }

        public void SetRandomDirection()
        {
            Random rnd = new Random();
            XDirection = rnd.Next(-1, 2);  // Slumpmässig riktning mellan -1, 0 och 1
            YDirection = rnd.Next(-1, 2);  // Slumpmässig riktning mellan -1, 0 och 1
        }

        public void Move(int gridWidth, int gridHeight)
        {
            X = (X + XDirection + gridWidth) % gridWidth;   // Hantera wrapping
            Y = (Y + YDirection + gridHeight) % gridHeight; // Hantera wrapping
        }
    }
}


