using System;
using System.Linq;

namespace P02_Sum_Numbers
{
    public class P02_Sum_Numbers
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(input.Length);
            Console.WriteLine(input.Sum());
        }
    }
}
