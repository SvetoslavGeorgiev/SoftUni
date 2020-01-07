using System;
using System.Linq;

namespace Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sums = { 0, 0 };

            for (int i = 0; i < numbers.Length; i++)
            {
                
                if (numbers[i] % 2 == 0)
                {
                    sums[0] += numbers[i];
                }
                else
                {
                    sums[1] += numbers[i];
                }
            }
            Console.WriteLine(sums[0] - sums[1]);
        }
    }
}
