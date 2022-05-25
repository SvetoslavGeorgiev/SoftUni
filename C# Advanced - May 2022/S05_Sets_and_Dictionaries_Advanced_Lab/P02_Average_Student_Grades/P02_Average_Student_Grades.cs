using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Average_Student_Grades
{
    class P02_Average_Student_Grades
    {
        static void Main()
        {
            var dict = new Dictionary<string, List<decimal>>();

            var entries = int.Parse(Console.ReadLine());

            for (int i = 0; i < entries; i++)
            {
                var entry = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (dict.ContainsKey(entry[0]))
                {
                    dict[entry[0]].Add(decimal.Parse(entry[1]));
                }
                else
                {
                    dict.Add(entry[0], new List<decimal>());
                    dict[entry[0]].Add(decimal.Parse(entry[1]));
                }
            }
            foreach (var name in dict)
            {
                Console.Write($"{name.Key} ->");
                for (int v = 0; v < name.Value.Count; v++)
                {
                    Console.Write($" {name.Value[v]:F2}");
                }
                Console.Write($" (avg: {name.Value.Average():F2})");
                Console.WriteLine();
            }
        }
    }
}
