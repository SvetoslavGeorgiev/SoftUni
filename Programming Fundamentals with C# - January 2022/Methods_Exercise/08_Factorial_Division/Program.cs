using System;

namespace _08_Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());

            double resultFactorialOfTheFirstNumber = GetFactorial(firstNumber);
            double resultFactorialOfTheSecondNumber = GetFactorial(secondNumber);

            Console.WriteLine($"{resultFactorialOfTheFirstNumber / resultFactorialOfTheSecondNumber:F2}");
        }

        private static double GetFactorial(int firstNumber)
        {
            var result = 1.00;

            for (int i = firstNumber; i >= 1; i--)
            {
                result *= i;
            }
            return result;
        }
    }
}