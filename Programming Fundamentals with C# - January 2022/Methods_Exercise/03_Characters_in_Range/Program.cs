using System;

namespace _03_Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var start = char.Parse(Console.ReadLine());
            var end = char.Parse(Console.ReadLine());

            PrintCharectersInRange(start, end);

        }

        private static void PrintCharectersInRange(char start, char end)
        {
            
            for (int i = Math.Min(start, end) + 1; i < Math.Max(start, end); i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}