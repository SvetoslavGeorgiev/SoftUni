using System;

namespace _08_Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = double.Parse(Console.ReadLine());
            var secondNumber = double.Parse(Console.ReadLine());

            double result = MathPower(firstNumber, secondNumber);
            Console.WriteLine(result);
        }

        private static double MathPower(double firstNumber, double secondNumber)
        {
            var result = 0.00;

            result = Math.Pow(firstNumber, secondNumber);
            return result;
        }
    }
}
