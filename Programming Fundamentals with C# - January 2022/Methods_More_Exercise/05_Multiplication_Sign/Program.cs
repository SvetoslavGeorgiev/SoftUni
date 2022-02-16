using System;

namespace _05_Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num1 = int.Parse(Console.ReadLine());
            var num2 = int.Parse(Console.ReadLine());
            var num3 = int.Parse(Console.ReadLine());


            PrintIsNegativePositiveOrZero(num1, num2, num3);
        }

        private static void PrintIsNegativePositiveOrZero(int num1, int num2, int num3)
        {
            var isContainsZero = false;
            var negativeCount = 0;
            if (num1 < 0)
            {
                negativeCount++;
            }
            if (num2 < 0)
            {
                negativeCount++;
            }
            if (num3 < 0)
            {
                negativeCount++;
            }
            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                isContainsZero = true;
            }
            if (isContainsZero)
            {
                Console.WriteLine("zero");
            }
            if (negativeCount %2 != 0)
            {
                Console.WriteLine("negative");
            }
            else
            {
                if (!isContainsZero)
                {
                    Console.WriteLine("positive");
                }
            }
        }
    }
}