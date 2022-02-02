using System;
using System.Linq;

namespace _06_Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                   .Split()
                   .Select(int.Parse)
                   .ToArray();

            var rightSum = 0;
            var leftSum = 0;
            var index = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr.Length == 1)
                {
                    index++;
                    break;
                }
                else
                {
                    for (int k = i + 1; k < arr.Length; k++)
                    {
                        rightSum += arr[k];
                    }
                    for (int j = i - 1; j >= 0; j--)
                    {
                        leftSum += arr[j];
                    }
                    if (leftSum == rightSum)
                    {
                        index = i;
                    }
                    leftSum = 0;
                    rightSum = 0;
                }
            }
            if (index != -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
