using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Knights_of_Honor
{
    public class P02_Knights_of_Honor
    {
        static void Main()
        {
            var input = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            Action<string> print = Print(input);

            input.ForEach(print);
        }

        private static Action<string> Print(List<string> input)
        {
            return name => Console.WriteLine($"Sir {name}");
        }
    }
}
