using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Action_Print
{
    public class P01_Action_Print
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
            return name => Console.WriteLine(name);
        }
    }
}
