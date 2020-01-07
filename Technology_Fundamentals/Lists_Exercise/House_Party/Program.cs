using System;
using System.Collections.Generic;
using System.Linq;

namespace House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeOfInput = int.Parse(Console.ReadLine());

            List<string> peopleToTheParty = new List<string>();

            for (int i = 1; i <= timeOfInput; i++)
            {
                string command = Console.ReadLine();

                string[] commandToArray = command.Split();

                if (commandToArray[2] != "not")
                {
                    if (peopleToTheParty.Contains(commandToArray[0]))
                    {
                        Console.WriteLine($"{commandToArray[0]} is already in the list!");
                    }
                    else if (!peopleToTheParty.Contains(commandToArray[0]))
                    {
                        peopleToTheParty.Add(commandToArray[0]);
                    }
                }
                else
                {
                    if (peopleToTheParty.Contains(commandToArray[0]))
                    {
                        peopleToTheParty.Remove(commandToArray[0]);
                    }
                    else if (!peopleToTheParty.Contains(commandToArray[0]))
                    {
                        Console.WriteLine($"{commandToArray[0]} is not in the list!");
                    }
                }
            }
            foreach (var item in peopleToTheParty)
            {
                Console.WriteLine(item);
            }
        }
    }
}
