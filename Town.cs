using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class Town
    {
        public static void PrintTown()
        {
            string[,] locations = new string[26, 101];
            string[,] matris = new string[26, 101];
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    if (i == 0 || i == 25)
                    {
                        matris[i, j] = "-";
                    }
                    else if (j == 0 || j == 100)
                    {
                        matris[i, j] = "|";
                    }
                    else if (matris[i,j]==null && locations[i,j]== "c")
                    {
                        matris[i,j] = "C";
                    }
                    else
                    {
                        matris[i, j] = " ";
                    }
                    
                    
                }
               

            }
            for (int k = 0; k < matris.GetLength(0); k++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    Console.Write(matris[k, j]);
                }
                Console.WriteLine();
            }



        }
    }
}







