using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "end")
            {


                string[] temp = command.Split();


                if (temp[0] == "Add")
                {
                    numbers.Add(int.Parse(temp[1]));
                }
                else if (temp[0] == "Remove")
                {
                    numbers.Remove(int.Parse(temp[1]));
                }
                else if (temp[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(temp[1]));
                }
                else if (temp[0] == "Insert")
                {
                    int number = int.Parse(temp[1]);
                    int index = int.Parse(temp[2]);
                    numbers.Insert(index, number);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
