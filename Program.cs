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
            for (int i = 0;i < AmountOfCitizens; i++)
            {
                Citizen citizen = new Citizen();
                PeopleInTown.Add(citizen);
            }
            for(int i = 0; i < AmountOfPolis; i++)
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
            List<Person> PeopleInTown = new List<Person>();
            Town town = new Town();
            MakePeople(AmountofRobbers, AmountofCitizens, AmountofPolis, ref PeopleInTown);
            

            
            Console.WriteLine("Cops and Robbers");
            Town.PrintTown(town);
            foreach (Person person in PeopleInTown) 
            {
                Console.WriteLine(person.Name);           
            }
                      
            
           
            Console.ReadLine();
   
        }
    }
}
