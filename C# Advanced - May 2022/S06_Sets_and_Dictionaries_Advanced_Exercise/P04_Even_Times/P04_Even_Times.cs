using System;
using System.Collections.Generic;

namespace P04_Even_Times
{
    class P04_Even_Times
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            var dict = new Dictionary<int, int>();


            for (int i = 0; i < lines; i++)
            {

                var currentNumber = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(currentNumber))
                {
                    dict.Add(currentNumber, 0);
                }
                dict[currentNumber]++;
            }

            if (dict.Count > 0)
            {
                foreach (var kvp in dict)
                {
                    if (kvp.Value % 2 == 0)
                    {
                        Console.WriteLine(kvp.Key);
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}
