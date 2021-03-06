﻿using System;
using System.Linq;

namespace Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(", ", input);
            Console.WriteLine(result);
        }
    }
}
