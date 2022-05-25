using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Count_Same_Values_in_Array
{
    class P01_Count_Same_Values_in_Array
    {
        static void Main()
        {
            
            var dic = new Dictionary<double, int>();

            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {

                if (!dic.ContainsKey(input[i]))
                {
                    dic.Add(input[i], 0);
                }
                dic[input[i]]++;
            }

            foreach (var kvp in dic)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }

        }
    }
}
