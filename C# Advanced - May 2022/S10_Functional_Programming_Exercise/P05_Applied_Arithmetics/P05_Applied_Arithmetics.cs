﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Applied_Arithmetics
{
    public class P05_Applied_Arithmetics
    {
        static void Main()
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
                    Func<List<int>, List<int>> calculations = Calculations(command);
                    numbers = calculations(numbers);
                }
                else
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }



        private static Func<List<int>, List<int>> Calculations(string command)
        {
            switch (command)
            {
                case "add":
                    return x => x.Select(n => n += 1).ToList();
                case "subtract":
                    return x => x.Select(n => n -= 1).ToList();
                case "multiply":
                    return x => x.Select(n => n *= 2).ToList();
                default:
                    return null;
            }
        }
    }
}
