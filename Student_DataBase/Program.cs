using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassMatesLab
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool goOn = true;
            while (goOn == true)
            {
                List<string> names = new List<string>() { "Mark Haines", "James Moulton", "Andrew Klim", "Tommy Waalkes", "Maggie Tamanini", "Jerome Brown", "Trent", "Troy Vizina", "Kevin Jackson II", "Joshua Carolin", "Sean Boatman", "Kate Datema" };
                List<string> foods = new List<string>() { "Cilantro", "Sushi", "Sushi", "Chicken Curry", "Movie theatre Popcorn", "Italian Cuisine", "Tacos", "Broccoli", "Asian cuisine", "Nalesniki", "Meat", "Pizza" };
                List<string> hometown = new List<string>() { "Grand Rapids", "Toledo", "Grayslake", "Raleigh NC", "Montrose, MI", "Wilwaukee, WI", "Rochester, MI", "Indian River, MI", "Detroit", "Northville, MI", "Eaton Rapids, MI", "Zeeland, MI" };

                PrintWholeList(names);
                //Console readline can only give us a string 
                //sp to use it as an index we must convert it to an int 
                string input = GetUserInput("Which person would you like to learn about?");

                bool resultOfChar = input.All(c => Char.IsLetter(c) || c == ' '); ;
                int index;

                if (resultOfChar == true)
                {
                    while (input.All(c => Char.IsLetter(c) || c == ' ') == true)
                    {
                        Console.WriteLine("Your input has a character that we don't accepted, input numbers 0 - 11 only next time.");
                        input = GetUserInput("please enter a number (0-11)");
                    }

                    index = int.Parse(input);


                }
                else
                {
                    index = int.Parse(input);
                }

                

                if (index > 11 || index < 0 )
                {
                    while (index > 11 || index < 0)
                    {
                        Console.Write("try again, please enter a number between 0 and 11");
                        Console.WriteLine( );
                        index = int.Parse(GetUserInput("Which person would you like to learn about?"));
                    }

                }    
                string name = names[index];
                string input2 = GetUserInput($"What would you like to learn about {name}? hometown or favorite food");
                if (input2 != "hometown" && input2 != "favorite food")
                {
                    while (input2 != "hometown" && input2 != "favorite food")
                    {
                        Console.WriteLine("I'm not sure what you meant, please try again");
                        Console.WriteLine();
                        input2 = GetUserInput($"What would you like to learn about {name}? hometown or favorite food");
                    }
                    if (input2 == "hometown")
                    {
                        string ht = hometown[index];
                        Console.WriteLine(ht);
                    }
                    else
                    {
                        string food = foods[index];
                        Console.WriteLine(food);
                    }
                }
                else if (input2 == "hometown")
                {
                    string ht = hometown[index];
                    Console.WriteLine(ht);
                }
                else
                {
                    string food = foods[index];
                    Console.WriteLine(food);
                }


                goOn = GetContinue();
            }
        }


        

        public static void PrintWholeList(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i}: {items[i]}");
            }
        }
      

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().ToLower().Trim();
            return input;
        }

        

        public static bool GetContinue()
        {
            Console.WriteLine("Would you like to look up another person? y/n");
            string answer = Console.ReadLine();

            //There are 3 cases we care about 
            //1) y - we want to continue 
            //2) n - we want to stop 
            //3) anything else - we want to try again

            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand that, please try again");
                //Calling a method inside itself is called recursion
                //Think of this as just trying again 
                return GetContinue();
            }
        }
    }
}