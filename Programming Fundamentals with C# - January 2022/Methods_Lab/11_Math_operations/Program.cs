using System;

namespace _11_Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = double.Parse(Console.ReadLine());
            var @operator = char.Parse(Console.ReadLine());
            var secondNumber = double.Parse(Console.ReadLine());

            double result = Calculation(firstNumber, secondNumber, @operator);
            Console.WriteLine(result);
        }

        private static double Calculation(double firstNumber, double secondNumber, char @operator)
        {
            double result = 0;

            switch (@operator)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
                case '/':
                    result = firstNumber / secondNumber;
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
