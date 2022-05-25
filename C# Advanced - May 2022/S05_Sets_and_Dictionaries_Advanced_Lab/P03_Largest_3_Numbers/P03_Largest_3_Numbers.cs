using System;
using System.Linq;

namespace P03_Largest_3_Numbers
{
    class P03_Largest_3_Numbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x => x).ToList();

            var count = numbers.Count() >= 3 ? 3 : numbers.Count();

            for (int i = 0; i < count; i++)
                Console.Write($"{numbers[i]} ");


        }
    }
}
