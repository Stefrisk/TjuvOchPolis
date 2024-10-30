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
                if (peopleInTown[i] is Robber robber)
                {
                    int x = robber.XLocation;
                    int y = robber.YLocation;

                    if (town.PlayerLocations[x, y] is Citizen citizen)
                    {
                        robber.Inventory = Town.RobItem(robber, citizen);
                    }

                }
                if (peopleInTown[i] is Police police)
                {
                    int x = police.XLocation;
                    int y = police.YLocation;

                    //Console.WriteLine(town.PlayerLocations[x, y].GetType());
                    //Thread.Sleep(100);

                    if (town.PlayerLocations[x, y] is Robber robber2)
                    {
                        Console.WriteLine("Här komer jag in");
                        Thread.Sleep(1000);
                        police.Inventory = Town.ConfiscateItem(police, robber2);
                    }
                }
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
