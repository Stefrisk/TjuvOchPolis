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
       
        static void Main(string[] args)
        {
            int AmountofRobbers = 10;
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

                Person.Move(PeopleInTown); // player moves onestep 
                Town.PlayerLocation2(PeopleInTown, ref town._playerLocations);// saves updated player location to the array
                Town.PrintTown(town);    //Print Town and player locations 
                Thread.Sleep(200);

            }








        }
    }
}
