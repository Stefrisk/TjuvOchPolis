using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TjuvOchPolis
{
    internal class Program
    {
        static Random rnd = new Random();

        public static async Task StartDelayedTask(Town town, int itemCount, Robber person, List<Person> PeopleInJail, List<Person> PeopleInTown)
        {
            await Task.Delay(itemCount * 10000);
            town.ReleasePrisoner(PeopleInJail, PeopleInTown, person, town); 
           
        }
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


        public static async Task RunAllInteractionsAsync(List<Person> peopleInTown, List<Person> peopleInJail, Town town)
        {
            var robbers = peopleInTown.Where(p => p.Character == "R").ToList();

            foreach (Robber robber in robbers)
            {
                town.HandleCitizenInteraction(town, robber);
                await town.HandlePoliceInteractionAsync(town, robber, peopleInTown, peopleInJail);
            }
        }


        static void Main(string[] args)
        {
            int AmountofRobbers = 15;
            int AmountofCitizens = 20;
            int AmountofPolis = 15;
            Town town = new Town();                            //Make town      
            List<Person> PeopleInTown = new List<Person>();
            List<Person> PeopleInJail = new List<Person>();   //make list of people and people in jail
            town.CitzensOnMap = AmountofCitizens;
            town.RobbersOnMap = AmountofRobbers;
            town.PoliceOnMap = AmountofPolis;
            MakePeople(AmountofRobbers, AmountofCitizens, AmountofPolis, ref PeopleInTown);//make people and add to list
            town.PlayerLocations = Town.PlayerLocation(PeopleInTown,town.PlayerLocations, town, PeopleInJail, town._jail); // save player start locations to town 
          

            while (true)
            {
                Console.Clear();

                Person.Move(PeopleInTown);                                          // player moves onestep 
                Person.MoveJail(PeopleInJail);
                
                Town.PlayerLocation(PeopleInTown, town._playerLocations, town, PeopleInJail, town._jail);           // saves updated player location to the array                

                RunAllInteractionsAsync(PeopleInTown,PeopleInJail, town);

                Town.PrintTown(town);                                               //Print Town and player locations 


                Thread.Sleep(500);
            }
        }
    }
}
