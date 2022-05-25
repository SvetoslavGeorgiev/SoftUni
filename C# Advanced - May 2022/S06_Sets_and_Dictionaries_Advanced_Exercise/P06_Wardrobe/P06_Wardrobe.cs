using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Wardrobe
{
    class P06_Wardrobe
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, int>>();


            for (int i = 0; i < lines; i++)
            {
                var currentLine = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var collor = currentLine[0];
                var clothes = currentLine[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!dict.ContainsKey(collor))
                {
                    dict.Add(collor, new Dictionary<string, int>());
                }
                foreach (var item in clothes)
                {
                    if (!dict[collor].ContainsKey(item))
                    {
                        dict[collor].Add(item, 0);
                    }
                    dict[collor][item]++;
                }
            }

            var itemLookingFor = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var collorKvp in dict)
            {
                Console.WriteLine($"{collorKvp.Key} clothes:");
                foreach (var itemKvp in collorKvp.Value)
                {
                    if (collorKvp.Key == itemLookingFor[0] && itemKvp.Key == itemLookingFor[1])
                    {
                        Console.WriteLine($"* {itemKvp.Key} - {itemKvp.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {itemKvp.Key} - {itemKvp.Value}");
                    }

                }
            }
        }
    }
}
