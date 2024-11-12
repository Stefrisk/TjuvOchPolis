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


        public static void  RunAllInteractions(List<Person> peopleInTown, List<Person> peopleInJail, Town town)
        {
            var robbers = peopleInTown.Where(p => p.Character == "R").ToList();

            foreach (Robber robber in robbers)
            {
                town.HandleCitizenInteraction(town, robber);
                Town.HandlePoliceInteraction(town, robber, peopleInTown, peopleInJail);
            }
        }


        static void Main(string[] args)
        {
            int AmountofRobbers = 15;                                                                               // we decide the amount of each type of player here 
            int AmountofCitizens = 50;
            int AmountofPolis = 10;

            Town town = new Town();                                                                                 //Make town      
            List<Person> PeopleInTown = new List<Person>(); 
            List<Person> PeopleInJail = new List<Person>();                                                         //make list of people in town and people in jail
            town.CitzensOnMap = AmountofCitizens;
            town.RobbersOnMap = AmountofRobbers;
            town.PoliceOnMap = AmountofPolis;
            MakePeople(AmountofRobbers, AmountofCitizens, AmountofPolis, ref PeopleInTown);                         //make people and add to list
            town.PlayerLocations = Town.PlayerLocation(PeopleInTown,town.PlayerLocations, town, PeopleInJail, town._jail); // save player start locations to town 
          

            while (true)
            {
                Console.Clear();

                Person.Move(PeopleInTown);                                                                          // player moves onestep 
                Person.MoveJail(PeopleInJail);
                
                Town.PlayerLocation(PeopleInTown, town._playerLocations, town, PeopleInJail, town._jail);           // saves updated player location to the town and jail array                

                RunAllInteractions(PeopleInTown,PeopleInJail, town);                                                // cross reference the lists locations and handle interactions

                Town.PrintTown(town);                                                                                //Print Town and player locations 


                Thread.Sleep(10);                                                                                     // Sets speed of while loop 
            }
        }
    }
}
