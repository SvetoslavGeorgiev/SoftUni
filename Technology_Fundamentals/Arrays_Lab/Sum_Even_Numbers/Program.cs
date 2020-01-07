using System;
using System.Linq;

namespace Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                // for .Select and .ToArray we need to use "System.Linq" for using
                .Select(int.Parse)
                .ToArray();
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber % 2 == 0)
                {
                    sum += currentNumber;
                }
            }

            Console.WriteLine(sum);

        }
    }
}
