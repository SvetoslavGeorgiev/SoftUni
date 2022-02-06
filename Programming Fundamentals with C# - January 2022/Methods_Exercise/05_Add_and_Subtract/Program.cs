using System;

namespace _05_Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var thirdNumber = int.Parse(Console.ReadLine());

            int sumOfTheFirstTwo = SumOfTheFirstTwo(firstNumber, secondNumber);
            int resultOfSubtractingThirdNumFromSumOfTheFirstTwo = SubtractThirdNumFromSumOfTheFirstTwo(thirdNumber, sumOfTheFirstTwo);

            Console.WriteLine(resultOfSubtractingThirdNumFromSumOfTheFirstTwo);
        }

        private static int SubtractThirdNumFromSumOfTheFirstTwo(int thirdNumber, int sumOfTheFirstTwo)
        {
            return sumOfTheFirstTwo - thirdNumber;
        }

        private static int SumOfTheFirstTwo(int firstNumber, int secondNumber)
        {
            return  firstNumber + secondNumber;
        }
    }
}
