﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    public class Town
    {

        public string[,] _karta = new string[27, 122];
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
        public Person[,] _playerLocations = new Person[27, 122];
        public Person[,] PlayerLocations
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
        public Stack<string> _interactions = new Stack<string>();
        public Stack<string> Interactions
        {
            get { return _interactions; }
            set { _interactions = value; }

        }

        


        public static void PrintTown(Town town)
        {

            for (int i = 0; i < town.Karta.GetLength(0); i++)
            {
                for (int j = 0; j < town.Karta.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        town.Karta[i, j] = "_";
                    }
                    else if (i == 26)
                    {
                        town.Karta[i, j] = "¯";
                    }
                    else if (j == 0 || j == 101 || j == 121)
                    {
                        town.Karta[i, j] = "|";
                    }
                    else if(j == 105 && i < 11)
                    {
                        town.Karta[i, j] = "|";
                    }
                    else if(i == 11 && j > 105)
                    {
                        town.Karta[i, j] = "¯";
                    }
                    else if (i == 0 && j > 105)
                    {
                        town.Karta[i, j] = "_";
                    }                  
                    else if (town.PlayerLocations != null && town.PlayerLocations[i, j] != null && !string.IsNullOrEmpty(town.PlayerLocations[i, j].Character))
                    {
                        town.Karta[i, j] = town.PlayerLocations[i, j].Character;
                    }
                    else
                    {
                        town.Karta[i, j] = " ";
                    }
                }
            }
            
            town.Karta[13, 109] = "P";
            town.Karta[13, 110] = "R";
            town.Karta[13, 111] = "I";
            town.Karta[13, 112] = "S";
            town.Karta[13, 113] = "O";
            town.Karta[13, 114] = "N";

            for (int i = 0; i < town.Karta.GetLength(0); i++)
            {
                for (int j = 0; j < town.Karta.GetLength(1); j++)
                {
                    Console.Write(town.Karta[i, j]);

                }
                Console.WriteLine();
            }
            string[] recentInteractions = town._interactions.ToArray();
            int itemsToPrint = Math.Min(5, recentInteractions.Length);
            for (int i = 0; i < itemsToPrint; i++)
            {
                Console.WriteLine(recentInteractions[i]);
            }
            
        }

        public static Person[,] PlayerLocation(List<Person> ListOfPeople, Person[,] PlayerLocations)
        {
            Array.Clear(PlayerLocations, 0, PlayerLocations.Length);
            for (int i = 0; i < ListOfPeople.Count; i++)
            {
                int x = ListOfPeople[i].XLocation;
                int y = ListOfPeople[i].YLocation;

                PlayerLocations[x, y] = ListOfPeople[i];

            }

            return PlayerLocations;
        }


        //public static List<Item> RobItem(List<Person> peopleInTown, Town town)
        //{
        //    //Random rnd = new Random();
        //    //if (citizen.Inventory.Any())
        //    //{
        //    //    Item item = citizen.Inventory[rnd.Next(0, citizen.Inventory.Count)];
        //    //    citizen.Inventory.Remove(item);
        //    //    robber.Inventory.Add(item);

        //    //    town._interactions.Push($"Tjuven {robber.Name} stal {item.Namn} från {citizen.Name}");

        //    //}
        //    return robber.Inventory;
        //}

        //public static List<Item> ConfiscateItem(List<Person> peopleInTown, Town town)
        //{
        //    Console.WriteLine("Här kom jag in!");
        //    Thread.Sleep(1000);
        //    if (robber.Inventory.Any())
        //    {
        //        for (int i = 0; i < robber.Inventory.Count; i++)
        //        {
        //            Item item = robber.Inventory[i];
        //            robber.Inventory.Remove(item);
        //            police.Inventory.Add(item);
        //            town._interactions.Push($"Polisen {police.Name} beslagtog {item.Namn} från {robber.Name}");
        //            Thread.Sleep(1000);
        //        }

        //        Thread.Sleep(2500);
        //    }
        //    return police.Inventory;
    }
}







