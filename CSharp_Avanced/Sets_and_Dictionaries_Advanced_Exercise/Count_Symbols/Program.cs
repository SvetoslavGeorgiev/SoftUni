using System;
using System.Linq;
using System.Collections.Generic;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            var dict = new SortedDictionary<char, int>();

            foreach (var item in input)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 0);
                }
                dict[item]++;
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
