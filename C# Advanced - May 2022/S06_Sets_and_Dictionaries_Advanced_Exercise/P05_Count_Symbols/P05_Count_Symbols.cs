using System;
using System.Collections.Generic;

namespace P05_Count_Symbols
{
    class P05_Count_Symbols
    {
        static void Main()
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
