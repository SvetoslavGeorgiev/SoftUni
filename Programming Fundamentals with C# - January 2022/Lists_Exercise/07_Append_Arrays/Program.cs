using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split("|")
                .Reverse()
                .ToList();

            var numbers = new List<string>();

            foreach (var item in input)
            {
                var temp = item.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                temp.ForEach(x => numbers.Add(x));
            }

            numbers.ForEach(x => Console.Write($"{x} "));
        }
    }
}
