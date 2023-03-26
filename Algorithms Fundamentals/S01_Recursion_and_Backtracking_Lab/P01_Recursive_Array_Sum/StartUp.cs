namespace P01_Recursive_Array_Sum
{
    using System;
    using System.Linq;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            var index = 0;

            var arr = Console.ReadLine().Split().Select(x => int.Parse(x.ToString())).ToArray();

            Console.WriteLine(GetSum(arr, index));
        }

        private static int GetSum(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                return 0;
            }

            return arr[index] + GetSum(arr, index + 1);
        }
    }
}