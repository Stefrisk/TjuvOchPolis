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
        static Random rnd = new Random();
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
        public int ItemCount { get; set; } = 0;
        public string[,] _jail = new string[11, 11];
        public string[,] Jail
        {
            get { return _jail; }
            set { _jail = value; }
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



            Console.WriteLine($"Players on map:{town.PlayersOnMap}  Citizens:{town.CitzensOnMap}  Police:{town.PoliceOnMap}  Robbers:{town.RobbersOnMap} \n Citizens robbed:{town.CitizensRobbed}  Robbers taken:{town.RobbersTaken}  Robbers in jail:{town.RobbersInJail}");


            for (int i = 0; i < town.Karta.GetLength(0); i++)
            {
                for (int j = 0; j < town.Karta.GetLength(1); j++)
                {
                    Console.Write(town.Karta[i, j]);

                }
                Console.WriteLine();
            }

            for (int i = 0; i < town.Jail.GetLength(0); i++) // fill jail string array with map edges 
            {
                for (int j = 0; j < town.Jail.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        town.Jail[i, j] = "_";
                    }
                    else if (i == 10)
                    {
                        town.Jail[i, j] = "¯";
                    }
                    else if (j == 0 || j == 10)
                    {
                        town.Jail[i, j] = "|";

                    }
                    else if (string.IsNullOrEmpty(town.Jail[i, j]))
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
            string[] recentInteractions = town._interactions.ToArray();
            int itemsToPrint = Math.Min(5, recentInteractions.Length);
            for (int i = 0; i < itemsToPrint; i++)
            {
                Console.WriteLine(recentInteractions[i]);  // prints interactions 
            }


        }

        public static Person[,] PlayerLocation(List<Person> ListOfPeople, Person[,] PlayerLocations, Town town, List<Person> PeopleInJail, String[,] Jail)
        {
            town.PlayersOnMap = ListOfPeople.Count;

            Array.Clear(PlayerLocations, 0, PlayerLocations.Length);
            Array.Clear(Jail, 0, Jail.Length);

            for (int i = 0; i < ListOfPeople.Count; i++)
            {
                int x = ListOfPeople[i].XLocation;
                int y = ListOfPeople[i].YLocation;

                PlayerLocations[x, y] = ListOfPeople[i];

            }
          

            for (int i = 0; i < PeopleInJail.Count; i++)
            {
                 int x = PeopleInJail[i].XLocation;
                 int y = PeopleInJail[i].YLocation;

                 Jail[x, y] = PeopleInJail[i].Character;
            }
            for (int i = 0; i < PeopleInJail.Count; i++) 
            {
                DateTime Now = DateTime.Now;
               int prisonTime = PeopleInJail[i].ItemsStolen * 10;
                TimeSpan Prison = Now - PeopleInJail[i].StartTime;
                
                if (Prison.TotalSeconds >= prisonTime)
                {
                    ReleasePrisoner(PeopleInJail, ListOfPeople, PeopleInJail[i], town);
                }
            }

            return PlayerLocations;
        }

        public static void ReleasePrisoner(List<Person> PeopleInJail, List<Person> PeopleInTown, Person person, Town town)
        {
            PeopleInJail.Remove(person);
            PeopleInTown.Add(person);
            town.RobbersInJail--;
            town._interactions.Push($"Tjuven {person.Name} blev frisläppt");
        }

        public void HandleCitizenInteraction(Town town, Person robber)
        {
            int x = robber.XLocation;
            int y = robber.YLocation;

            var citizen = town.PlayerLocations[x, y];
            if (citizen?.Character == "C" && citizen.Inventory.Any())
            {
                var item = citizen.Inventory[rnd.Next(citizen.Inventory.Count)];
                citizen.Inventory.Remove(item);
                robber.Inventory.Add(item);
                town._interactions.Push($"Tjuven {robber.Name} stal {item.Namn} från {citizen.Name}");
                town.CitizensRobbed++;
                town.ItemCount++;
            }
        }

        public static Robber HandlePoliceInteraction(Town town, Robber robber, List<Person> peopleInTown, List<Person> peopleInJail)
        {
            int x = robber.XLocation;
            int y = robber.YLocation;

            if (town.PlayerLocations[x, y]?.Character == "P" && robber.Inventory.Count > 0)
            {
                var items = robber.Inventory.ToList();
                robber.Inventory.Clear();
                town.RobbersTaken++;
                town.RobbersInJail++;
                town.ItemCount++;

                foreach (var item in items)
                {
                    town.PlayerLocations[x, y].Inventory.Add(item);
                    town._interactions.Push($"Polisen {town.PlayerLocations[x, y].Name} beslagtog {item.Namn} från {robber.Name}");
                }
                robber.ItemsStolen = items.Count;
                robber.StartTime = DateTime.Now;
                peopleInJail.Add(robber);
                peopleInTown.Remove(robber);

                robber.XLocation = robber.RandomStartPosJailX();
                robber.YLocation = robber.RandomStartPosJailY();
                town._jail[robber.XLocation, robber.YLocation] = "R";



            }
                return robber;
        }
    }
}






