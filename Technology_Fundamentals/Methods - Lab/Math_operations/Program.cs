using System;

namespace Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumenr = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double result = MathOperations(firstNumenr, operation, secondNumber);

            Console.WriteLine($"{result:F2}");
        }

        private static double MathOperations(int firstNumenr, char operation, int secondNumber)
        {
            int result = 0;
            // hire if someone want can be swich as well not with if else if,
            // and the operation can be with string also
            // and if you want variable to be operator need @ at the begining (@operator)
            if (operation == '*')
            {
                result = firstNumenr * secondNumber;
            }
            else if (operation == '/')
            {
                result = firstNumenr / secondNumber;
            }
            else if (operation == '+')
            {
                result = firstNumenr + secondNumber;
            }
            else
            {
                result = firstNumenr - secondNumber;
            }
            return result;
        }
    }
}
