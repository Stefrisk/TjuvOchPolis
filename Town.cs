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

        public Town()
        {
            InitiatePlayerLocation(ref _playerLocations);
        }

        public static void PrintTown(Town town)
        {
            for (int i = 0; i < town.Karta.GetLength(0); i++)
            {
                for (int j = 0; j < town.Karta.GetLength(1); j++)
                {
                    town.Karta[i, j] = " "; // Fyll med tomma strängar
                }
            }

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
                    else if (j == 0 || j == 101)
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
           
            for (int i = 0; i < town.Karta.GetLength(0); i++)
            {
                for (int j = 0; j < town.Karta.GetLength(1); j++)
                {
                    Console.Write(town.Karta[i, j]);
                    
                }
                Console.WriteLine();
            }
        }
        
        public static Person[,] PlayerLocation(List<Person> ListOfPeople, Person[,] PlayerLocations)
        {
            Array.Clear(PlayerLocations, 0, PlayerLocations.Length);
            for (int i = 0; i < ListOfPeople.Count; i++)
            {

                int x = ListOfPeople[i].XLocation;
                int y = ListOfPeople[i].YLocation;

                PlayerLocations[x, y] = ListOfPeople[i];

               
                if (ListOfPeople[i] is Robber)
                {
                    
                     if (PlayerLocations[x, y] is Citizen citizen)
                     {
                         ListOfPeople[i].Inventory = RobItem((Robber)ListOfPeople[i], citizen);
                     }
                }
             
            }
            return PlayerLocations;
        }


        public static List<Item> RobItem (Person robber, Citizen citizen)
        {
            Random rnd = new Random();
            if(citizen.Inventory.Any())
            {
                Item item = citizen.Inventory[rnd.Next(0, citizen.Inventory.Count)];
                citizen.Inventory.Remove(item);
                robber.Inventory.Add(item);

                Console.WriteLine($"Tjuven {robber.Name} stal {item.Namn} från {citizen.Name}");
                Thread.Sleep(3500);
            }
            return robber.Inventory;
        }

        public static void InitiatePlayerLocation(ref Person[,] PlayerLocations)
        {
            for (int i = 0; i < PlayerLocations.GetLength(0); i++)
            {
                for (int j = 0; j < PlayerLocations.GetLength(1); j++)
                {
                    PlayerLocations[i, j] = new Person(); // Lägg till en tom `Person`-instans
                }
            }

        }
    }

}







