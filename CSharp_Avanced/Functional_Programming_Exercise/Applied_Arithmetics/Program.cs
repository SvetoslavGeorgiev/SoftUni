using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command != "print")
                {
                    Func<int, int> calculations = Calculations(command);
                    numbers = numbers.Select(x => x = calculations(x)).ToList();

                    // Second Solution
                    //Func<List<int>, List<int>> calculations = Calculations(command);
                    //numbers = calculations(numbers);
                }
                else
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }

        private static Func<int, int> Calculations(string command)
        {
            switch (command)
            {
                case "add":
                    return x => x + 1;
                case "subtract":
                    return x => x - 1;
                case "multiply":
                    return x => x * 2;
                default:
                    return null;
            }
        }

        // Second Solution
        //private static Func<List<int>, List<int>> Calculations(string command)
        //{
        //    switch (command)
        //    {
        //        case "add":
        //            return x => x.Select(n => n += 1).ToList();
        //        case "subtract":
        //            return x => x.Select(n => n -= 1).ToList();
        //        case "multiply":
        //            return x => x.Select(n => n *= 2).ToList();
        //        default:
        //            return null;
        //    }
        //}
    }
}
