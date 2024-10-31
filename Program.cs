using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TjuvOchPolis
{
    internal class Program
    {
        public static void MakePeople(int AmountOfRobbers, int AmountOfCitizens, int AmountOfPolis, ref List<Person> PeopleInTown)
        {
            for (int i = 0; i < AmountOfRobbers; i++)
            {
                Robber robber = new Robber();
                PeopleInTown.Add(robber);
            }
            for (int i = 0; i < AmountOfCitizens; i++)
            {
                Citizen citizen = new Citizen();
                PeopleInTown.Add(citizen);
            }
            for (int i = 0; i < AmountOfPolis; i++)
            {
                Police police = new Police();
                PeopleInTown.Add(police);
            }
        }


        public static void RunAllInteractions(List<Person> peopleInTown, Town town)
        {
            for (int i = 0; i < peopleInTown.Count; i++)
            {
                if (peopleInTown[i].Character == "R")
                {
                    int x = peopleInTown[i].XLocation;
                    int y = peopleInTown[i].YLocation;

                    if (town.PlayerLocations[x, y].Character == "C")
                    {
                        Random rnd = new Random();
                        if (town.PlayerLocations[x, y].Inventory.Any())
                        {
                            Item item = town.PlayerLocations[x, y].Inventory[rnd.Next(0, town.PlayerLocations[x, y].Inventory.Count)];
                            town.PlayerLocations[x, y].Inventory.Remove(item);
                            peopleInTown[i].Inventory.Add(item);

                            town._interactions.Push($"Tjuven {peopleInTown[i].Name} stal {item.Namn} från {town.PlayerLocations[x, y].Name}");

                        }
                        
                    }
                    

                }
                
            }
            for (int i = 0; i < peopleInTown.Count; i++)
            {
                if (peopleInTown[i].Character == "R")
                {
                    int x = peopleInTown[i].XLocation;
                    int y = peopleInTown[i].YLocation;
                    



                    if (town._playerLocations[x, y].Character == "P")
                    {
                        

                        if (peopleInTown[i].Inventory.Count > 0)
                        {

                            for (int j = 0; j < peopleInTown[i].Inventory.Count; j++)
                            {
                                Item item = peopleInTown[i].Inventory[j];
                                peopleInTown[i].Inventory.Remove(item);
                                town._playerLocations[x, y].Inventory.Add(item);
                                town._interactions.Push($"Polisen {town._playerLocations[x, y].Name} beslagtog {item.Namn} från {peopleInTown[i].Name}");

                            }


                        }

                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int AmountofRobbers = 15;
            int AmountofCitizens = 20;
            int AmountofPolis = 15;
            List<Person> PeopleInTown = new List<Person>();                     //make list of people
            Town town = new Town();                                             //Make town      
            MakePeople(AmountofRobbers, AmountofCitizens, AmountofPolis, ref PeopleInTown);//make people and add to list
            town.PlayerLocations = Town.PlayerLocation(PeopleInTown,town.PlayerLocations); // save player start locations to town 
            


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Cops and Robbers");

                Console.WriteLine();

                Person.Move(PeopleInTown);                                          // player moves onestep 
                
                Town.PlayerLocation(PeopleInTown, town._playerLocations);           // saves updated player location to the array                

                RunAllInteractions(PeopleInTown, town);



                Town.PrintTown(town);                                               //Print Town and player locations 
                Thread.Sleep(1);
            }
        }
    }
}
