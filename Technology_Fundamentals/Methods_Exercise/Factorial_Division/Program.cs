using System;

namespace Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double firstFactoriel = FactorielCalculator(firstNumber);
            double secondFactoriel = FactorielCalculator(secondNumber);

            double dividedResult = firstFactoriel / secondFactoriel;

            Console.WriteLine($"{dividedResult:F2}");
        }

        private static double FactorielCalculator(int number)
        {
            double result = 1.00;
            for (int i = 1; i <= number; i++)
            {
                if (i != 1)
                {
                    result += result * (i - 1);
                }
            }
            return result;
        }
    }
}
