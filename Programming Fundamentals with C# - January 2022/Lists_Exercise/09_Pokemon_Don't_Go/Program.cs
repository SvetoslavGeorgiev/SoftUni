using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace _09_Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var sum = 0;
            while (input.Any())
            {
                var index = int.Parse(Console.ReadLine());
                var removedNumber = input[index];
                sum += removedNumber;
                input.RemoveAt(index);

                Console.WriteLine(string.Join(" ", input));
                Console.WriteLine();
            }
        }
    }
}
