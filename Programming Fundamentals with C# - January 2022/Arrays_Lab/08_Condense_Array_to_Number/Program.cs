using System;
using System.Linq;

namespace _08_Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var condensed = new int[numbers.Length - 1];
            while (condensed.Length >= 1)
            {
                for (int i = 0; i < condensed.Length; i++)
                {
                    condensed[i] = numbers[i] + numbers[i + 1];
                }
                numbers = condensed;
                condensed = new int[numbers.Length - 1];
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
