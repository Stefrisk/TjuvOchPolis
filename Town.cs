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
                    else if (town.Karta[i, j] == null && town.PlayerLocations[i, j] == "c")
                    {
                        town.Karta[i, j] = "C";
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
    }
}







