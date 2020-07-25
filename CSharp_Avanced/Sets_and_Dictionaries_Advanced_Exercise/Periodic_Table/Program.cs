using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            var periodicTable = new SortedSet<string>();

            

            for (int i = 0; i < lines; i++)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (var element in command)
                {
                    periodicTable.Add(element);
                }
            }

            foreach (var element in periodicTable)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
