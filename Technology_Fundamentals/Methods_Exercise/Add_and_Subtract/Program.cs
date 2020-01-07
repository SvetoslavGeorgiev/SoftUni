using System;

namespace Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = 0;
            result = Sum(firstNumber, secondNumber);
            result = Subtract(result, thirdNumber);

            Console.WriteLine(result);

            string @new = Console.ReadLine();
        }

        private static int Subtract(int result, int thirdNumber)
        {
            return result - thirdNumber;
        }

        private static int Sum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}
