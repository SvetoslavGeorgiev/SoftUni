using System;
using System.Numerics;

namespace _03_Exact_Sum_of_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbersCount = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < numbersCount; i++)
            {
                var number = decimal.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);

        }
    }
}
