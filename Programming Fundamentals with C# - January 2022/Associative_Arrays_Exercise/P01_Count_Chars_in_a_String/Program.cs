using System;
using System.Collections.Generic;

namespace P01_Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine()
                .ToCharArray();

            var dic = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (c == ' ')
                {
                    continue;
                }
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else
                {
                    dic.Add(c, 1);
                }
            }

            foreach (var kvp in dic)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
            
        }
    }
}
