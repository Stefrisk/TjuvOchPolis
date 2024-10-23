namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Town town = new Town();
            
            string item = Console.ReadLine();
            Console.WriteLine("Cops and Robbers");
            Town.PrintTown(town);
                      
            Citizen citizen = new Citizen(3,3);
            town.Persons.Add(citizen);

            for (int i = 0; i < citizen.Inventory.Count; i++) 
            {
                Console.WriteLine(citizen.Inventory[i].Namn );
            }
            Console.WriteLine(citizen.Name);
            Console.ReadLine();
   
        }
    }
}
