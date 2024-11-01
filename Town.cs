using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Town
    {
        public int PlayersOnMap 
        {
            get;
            set; 
        }
        public int RobbersInJail { get; set; } = 0;
        public int RobbersTaken { get; set; } = 0;
        public int RobbersOnMap { get; set; } = 0;
        public int CitzensOnMap { get; set; } = 0;
        public int PoliceOnMap { get; set; } = 0;
        public int CitizensRobbed { get; set; } = 0;
        public string[,] _jail = new string[11, 11];
        public string[,] Jail
        {
            get {  return _jail; }
            set {  _jail = value; } 
        }

        public string[,] _karta = new string[27, 102];
        public string[,] Karta
        {
            get
            {
                return _karta;
            }
            set
            {
                _karta = value;
            }
        }
        public Person[,] _playerLocations = new Person[27, 102];
        public Person[,] PlayerLocations
        {
            get
            {
                return _playerLocations;
            }
            set
            {
                _playerLocations = value;
            }
        }
        public Stack<string> _interactions = new Stack<string>();
        public Stack<string> Interactions
        {
            get { return _interactions; }
            set { _interactions = value; }

        }

        


        public static void PrintTown(Town town)
        {

            for (int i = 0; i < town.Karta.GetLength(0); i++)
            {
                for (int j = 0; j < town.Karta.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        town.Karta[i, j] = "_";
                    }
                    else if (i == 26)
                    {
                        town.Karta[i, j] = "¯";
                    }
                    else if (j == 0 || j == 101 )
                    {
                        town.Karta[i, j] = "|";
                    }
                                     
                    else if (town.PlayerLocations != null && town.PlayerLocations[i, j] != null && !string.IsNullOrEmpty(town.PlayerLocations[i, j].Character))
                    {
                        town.Karta[i, j] = town.PlayerLocations[i, j].Character;
                    }
                    else
                    {
                        town.Karta[i, j] = " ";
                    }
                }
            }
            
            //town.Karta[13, 109] = "P";
            //town.Karta[13, 110] = "R";
            //town.Karta[13, 111] = "I";
            //town.Karta[13, 112] = "S";
            //town.Karta[13, 113] = "O";
            //town.Karta[13, 114] = "N";
            
            
            
           Console.WriteLine($"Players on map:{town.PlayersOnMap}  Citizens:{town.CitzensOnMap}  Police:{town.PoliceOnMap}  Robbers:{town.RobbersOnMap} \n Citizens robbed:{town.CitizensRobbed}  Robbers taken:{town.RobbersTaken}  Robbers in jail:{town.RobbersInJail}");
            

            for (int i = 0; i < town.Karta.GetLength(0); i++)
            {
                for (int j = 0; j < town.Karta.GetLength(1); j++)
                {
                    
                    Console.Write(town.Karta[i, j]);
                    


                }
                Console.WriteLine();
            }
            string[] recentInteractions = town._interactions.ToArray();
            int itemsToPrint = Math.Min(5, recentInteractions.Length);
            for (int i = 0; i < itemsToPrint; i++)
            {
                Console.WriteLine(recentInteractions[i]);  // prints interactions 
            }
            for (int i = 0;i < town.Jail.GetLength(0); i++) // fill jail string array with map edges 
            {
                for(int j = 0;j < town.Jail.GetLength(1); j++)
                {    if (i == 0)
                    {
                        town.Jail[i, j] = "_";
                    }
                    else if(i == 10)
                    {
                        town.Jail[i, j] = "¯";
                    }
                   else if (j == 0 || j == 10)
                    {
                        town.Jail[i, j] = "|";

                    }
                    //else if ( != null && town.PlayerLocations[i, j] != null && !string.IsNullOrEmpty(town.PlayerLocations[i, j].Character))
                    //{
                    //    town.Karta[i, j] = town.PlayerLocations[i, j].Character;                          print player jail location!!!
                    //}
                    else 
                    {
                        town.Jail[i, j] = " "; 
                            
                            
                    }
                   
                    
                }
            }
            for (int i = 0; i < town.Jail.GetLength(0); i++)
            {
                for (int j = 0; j < town.Jail.GetLength(1); j++)
                    
                {
                    Console.Write(town.Jail[i, j]);

                }
                Console.WriteLine();
            }
            
        }

        public static Person[,] PlayerLocation(List<Person> ListOfPeople, Person[,] PlayerLocations, Town town)
        {
            town.PlayersOnMap = ListOfPeople.Count;
            
            Array.Clear(PlayerLocations, 0, PlayerLocations.Length);
            for (int i = 0; i < ListOfPeople.Count; i++)
            {
                int x = ListOfPeople[i].XLocation;
                int y = ListOfPeople[i].YLocation;

                PlayerLocations[x, y] = ListOfPeople[i];

            }

            return PlayerLocations;
        }


        //public static List<Item> RobItem(List<Person> peopleInTown, Town town)
        //{
        //    //Random rnd = new Random();
        //    //if (citizen.Inventory.Any())
        //    //{
        //    //    Item item = citizen.Inventory[rnd.Next(0, citizen.Inventory.Count)];
        //    //    citizen.Inventory.Remove(item);
        //    //    robber.Inventory.Add(item);

        //    //    town._interactions.Push($"Tjuven {robber.Name} stal {item.Namn} från {citizen.Name}");

        //    //}
        //    return robber.Inventory;
        //}

        //public static List<Item> ConfiscateItem(List<Person> peopleInTown, Town town)
        //{
        //    Console.WriteLine("Här kom jag in!");
        //    Thread.Sleep(1000);
        //    if (robber.Inventory.Any())
        //    {
        //        for (int i = 0; i < robber.Inventory.Count; i++)
        //        {
        //            Item item = robber.Inventory[i];
        //            robber.Inventory.Remove(item);
        //            police.Inventory.Add(item);
        //            town._interactions.Push($"Polisen {police.Name} beslagtog {item.Namn} från {robber.Name}");
        //            Thread.Sleep(1000);
        //        }

        //        Thread.Sleep(2500);
        //    }
        //    return police.Inventory;
    }
}







