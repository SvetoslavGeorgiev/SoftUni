using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Custom_Min_Function
{
    public class P03_Custom_Min_Function
    {
        static void Main()
        {
            var input = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            Func<List<int>, int> checker = x => x.Min();

            var number = checker(input);

            Console.WriteLine(number);
        }
    }
}
