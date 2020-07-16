using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ').Select(double.Parse)
                .ToArray();

            var counts = new Dictionary<double, int>();


            foreach (var number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts.Add(number, 1);
                }

            }

            foreach (var count in counts)
            {
                Console.WriteLine($"{count.Key} - {count.Value} times");
            }

        }
    }
}
