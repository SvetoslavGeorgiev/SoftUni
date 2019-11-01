using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                var commandToArray = command.Split();

                if (commandToArray[0] == "Add")
                {
                    numbers.Add(int.Parse(commandToArray[1]));
                }
                else if (commandToArray[0] == "Insert")
                {
                    if (int.Parse(commandToArray[2]) >= 0 
                        && int.Parse(commandToArray[2]) <= numbers.Count)
                    {
                        numbers.Insert(int.Parse(commandToArray[2]), 
                            int.Parse(commandToArray[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commandToArray[0] == "Remove")
                {
                    if (int.Parse(commandToArray[1]) < numbers.Count 
                        && int.Parse(commandToArray[1]) >= 0)
                    {
                        numbers.RemoveAt(int.Parse(commandToArray[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commandToArray[0] == "Shift")
                {
                    if (commandToArray[1] == "left")
                    {
                        for (int i = 1; i <= int.Parse(commandToArray[2]); i++)
                        {
                            numbers.Add(numbers[0]);
                            numbers.RemoveAt(0);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= int.Parse(commandToArray[2]); i++)
                        {
                            numbers.Insert(0, numbers[numbers.Count - 1]);
                            numbers.RemoveAt(numbers.Count - 1);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
