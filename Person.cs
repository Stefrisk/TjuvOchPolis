using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Person
    {
        public string Name { get; set; }
        public int XLocation { get; set; }
        public int YLocation { get; set; }
        public int XDirection { get; set; }
        public int YDirection { get; set; }
        public List<Item> Inventory { get; set; }

        public Person()
        {
            
           
                XLocation = RandomStartPosX();
                YLocation = RandomStartPosY();
                Inventory = new List<Item>();
                SetRandomDirection();
                string name = GenerateRandomName();
                Name = name;


            
            
        }
        

        public void SetRandomDirection()
        {
            Random rnd = new Random();
            XDirection = rnd.Next(-1, 2);  // Slumpmässig riktning mellan -1, 0 och 1
            YDirection = rnd.Next(-1, 2);  // Slumpmässig riktning mellan -1, 0 och 1
        }

        public void Move(int gridWidth, int gridHeight)
        {
            XLocation = (XLocation + XDirection + gridWidth) % gridWidth;   // Hantera wrapping
            YLocation = (YLocation + YDirection + gridHeight) % gridHeight; // Hantera wrapping
        }
        public string GenerateRandomName()
        {
            string[] names = { "Alice", "Bob", "Charlie", "Diana", "Tom", "Justin", "Mikael", "Tod", "Moa", "Stefan", "Mattias","Joe","Noah",
    "Liam","Mason","Jacob","William","Ethan","James","Alexander","Michael","Benjamin","Elijah","Daniel","Aiden","Logan","Matthew","Lucas",
    "Jackson","David","Oliver","Jayden","Joseph","Gabriel","Samuel","Carter","Anthony","John","Dylan","Luke","Henry","Andrew","Isaac","Christopher",
    "Joshua","Wyatt","Sebastian","Owen","Caleb","Nathan","Ryan","Jack","Hunter","Levi","Christian","Jaxon","Julian","Landon","Grayson","Jonathan",
    "Isaiah","Charles","Thomas","Aaron","Eli","Connor","Jeremiah","Cameron","Josiah","Adrian","Colton","Jordan","Brayden","Nicholas","Robert",
    "Angel","Hudson","Lincoln","Evan","Dominic","Austin","Gavin","Nolan","Parker","Adam","Chase","Jace","Ian","Cooper","Easton","Kevin","Jose",
    "Tyler","Brandon","Asher","Jaxson","Mateo","Jason","Ayden","Zachary","Carson","Xavier","Leo","Ezra","Bentley","Sawyer","Kayden","Blake","Nathaniel",
    "Ryder" };
            Random rnd = new Random();
            string name  = names[rnd.Next(names.Length)];
            return name;
        }
        public int RandomStartPosX()
        {
            Random rndX = new Random();
            int x = rndX.Next(0, 100); // combine these 2 methods starting positions
            return x;
        }
        public int RandomStartPosY()
        {
            Random rndY = new Random();
            int y = rndY.Next(0, 100);
            return y;
        }

    }
}


