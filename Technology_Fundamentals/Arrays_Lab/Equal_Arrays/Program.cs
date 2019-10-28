using System;
using System.Linq;

namespace Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] sums = { 0, 0 };


            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical.Found difference at {i} index");
                    break;
                }
                sums[0] += arr1[i];
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                sums[1] += arr2[i];
            }

            if (sums[0] == sums[1])
            {
                Console.WriteLine($"Arrays are identical. Sum: {sums[0]}");
            }
        }
    }
}
