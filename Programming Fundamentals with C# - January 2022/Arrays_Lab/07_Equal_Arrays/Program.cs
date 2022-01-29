using System;
using System.Linq;

namespace _07_Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var arr2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var sum = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    sum += arr1[i];
                }
                else if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
