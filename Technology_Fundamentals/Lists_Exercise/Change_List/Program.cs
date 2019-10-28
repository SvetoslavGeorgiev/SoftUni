using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine();

            while (command != "end")
            {
                string[] temp = command.Split();

                if (temp[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == int.Parse(temp[1]));
                }
                else if (temp[0] == "Insert")
                {
                    int index = int.Parse(temp[2]);
                    int number = int.Parse(temp[1]);

                    numbers.Insert(index, number);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
