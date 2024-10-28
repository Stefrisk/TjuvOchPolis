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
        public string[,] _playerLocations = new string[27, 102];
        public string[,] PlayerLocations
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
        public static void PrintTown(Town town)
        {
            

            for (int i = 0; i < town.Karta.GetLength(0); i++)
            {
                for (int j = 0; j < town.Karta.GetLength(1); j++)
                {
                    if (i == 0 || i == 26)
                    {
                        town.Karta[i, j] = "-";
                    }
                    else if (j == 0 || j == 101)
                    {
                        town.Karta[i, j] = "|";
                    }
                    else if (!string.IsNullOrEmpty(town.PlayerLocations[i, j]))
                    {
                        town.Karta[i, j] = town.PlayerLocations[i,j];
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
        public static void PlayerLocation2(List<Person> ListOfPeople, ref string[,] PlayerLocations)
        {
            Array.Clear(PlayerLocations,0,PlayerLocations.Length);
            for (int i = 0; i < ListOfPeople.Count; i++) 
            {
                
                

                int x = ListOfPeople[i].XLocation;
               int y = ListOfPeople[i].YLocation;
               
                if (ListOfPeople[i] is Robber)
                {
                    PlayerLocations[x, y] = "R";
                }
                if (ListOfPeople[i] is Citizen)
                {
                    PlayerLocations[x, y] = "C";
                }
                if (ListOfPeople[i] is Police)
                {
                    PlayerLocations[x, y] = "P";
                }
                
            }
        }
        public static string[,] PlayerLocation(List<Person> ListOfPeople,string[,] PlayerLocations)
        {
            
            for (int i = 0; i < ListOfPeople.Count; i++)
            {
               
               

                
                int x = ListOfPeople[i].XLocation;
                int y = ListOfPeople[i].YLocation;
                

                if (ListOfPeople[i] is Robber)
                {
                    PlayerLocations[x, y] = "R";
                }
                if (ListOfPeople[i] is Citizen)
                {
                    PlayerLocations[x, y] = "C";
                }
                if (ListOfPeople[i] is Police)
                {
                    PlayerLocations[x, y] = "P";
                }

            }
            return PlayerLocations;
        }
    }
}







