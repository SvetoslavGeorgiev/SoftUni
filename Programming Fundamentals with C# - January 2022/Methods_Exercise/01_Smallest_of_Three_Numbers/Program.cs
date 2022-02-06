using System;

namespace _01_Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var thirdNumber = int.Parse(Console.ReadLine());

            int result = GetTheSmalestNumber(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(result);
        }

        private static int GetTheSmalestNumber(int firstNumber, int secondNumber, int thirdNumber)
        {
            var smalestNumberFromFirstTwo = Math.Min(firstNumber, secondNumber);

            return Math.Min(smalestNumberFromFirstTwo, thirdNumber);
        }
    }
}
