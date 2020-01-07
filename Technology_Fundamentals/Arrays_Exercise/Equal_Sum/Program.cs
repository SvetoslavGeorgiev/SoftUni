using System;
using System.Linq;

namespace Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int leftSum = 0;
            int rightSum = 0;

            int couterOfequals = 0;

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                for (int k = 0; k <= arr.Length - 1; k++)
                {
                    if (i > k)
                    {
                        leftSum += arr[k];
                    }
                    else if (i < k)
                    {
                        rightSum += arr[k];
                    }
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    couterOfequals++;
                }

                leftSum = 0;
                rightSum = 0;
            }
            if (couterOfequals == 0)
            {
                Console.WriteLine("no");
            }

        }
    }
}
