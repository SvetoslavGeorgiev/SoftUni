using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> sorted = numbers.OrderByDescending(x => x)
                .ToList();

            if (sorted.Count < 3)
            {
                for (int i = 0; i < sorted.Count; i++)
                {
                    Console.Write($"{sorted[i]} ");
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{sorted[i]} ");
                }
            }
        }
    }
}
