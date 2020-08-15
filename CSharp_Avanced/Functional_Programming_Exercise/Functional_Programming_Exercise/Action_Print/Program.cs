using System;
using System.Collections.Generic;
using System.Linq;

namespace Action_Print
{
    class Program
    {
        static void Main(string[] args)
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
            return name => Console.WriteLine(name);
        }
    }
}
