using System;

namespace _01_Sign_of_Integer_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            string result = isTheNumberPositiveNegativeOrZero(number);

            Console.WriteLine($"The number {number} is {result}.");
        }

        private static string isTheNumberPositiveNegativeOrZero(int number)
        {
            var result = string.Empty;
            if (number < 0)
            {
                result = "negative";
            }
            else if (number > 0)
            {
                result = "positive";
            }
            else
            {
                result = "zero";
            }
            return result;
        }
    }
}
