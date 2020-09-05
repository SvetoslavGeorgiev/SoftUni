using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            var evenNumbers = new List<int>();

            var oddNumbers = new List<int>();

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
                else
                {
                    oddNumbers.Add(number);
                }
            }
            var allNumbers = new List<int>();
            evenNumbers.Sort();
            evenNumbers.ForEach(x => allNumbers.Add(x));
            oddNumbers.Sort();
            oddNumbers.ForEach(x => allNumbers.Add(x));

        }
    }
}
