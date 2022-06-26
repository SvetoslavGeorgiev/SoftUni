using System;
using System.Diagnostics;
using System.Linq;

namespace P01_Recursive_Array_Sum
{
    public class P01_Recursive_Array_Sum
    {
        static void Main()
        {

            var arr  = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            long sum = SumArray(arr, 0);

            Console.WriteLine(sum);

        }

        private static long SumArray(int[] arr, int startIndex)
        {
            if (startIndex == arr.Length - 1)
            {
                return arr[startIndex];
            }

            long sum = arr[startIndex] + SumArray(arr, startIndex + 1);

            return sum;

        }
    }
}
