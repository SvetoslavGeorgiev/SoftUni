using System;
using System.Linq;

namespace _10_Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = Math.Abs(int.Parse(Console.ReadLine()));
            var numberToString = number.ToString();

            int sumOfTheEvenDigets = GetSumOfEvenDigets(numberToString);
            int sumOfTheOddDigets = GetSumOfOddDigets(numberToString);

            int result = GetMultipleOfEvenAndOdds(sumOfTheEvenDigets, sumOfTheOddDigets);
            Console.WriteLine(result);

        }

        private static int GetMultipleOfEvenAndOdds(int sumOfTheEvenDigets, int sumOfTheOddDigets)
        {
            var result = 0;
            return result = sumOfTheOddDigets * sumOfTheEvenDigets;

        }

        private static int GetSumOfOddDigets(string numberToString)
        {
            var sumOfTheOddDigets = 0;
            var values = numberToString
                .Select(x => (int)char.GetNumericValue(x))
                .ToArray();
            foreach (var number in values)
            {
                if (number % 2 == 1)
                {
                    sumOfTheOddDigets += number;
                }
            }
            return sumOfTheOddDigets;
        }

        private static int GetSumOfEvenDigets(string numberToString)
        {
            var sumOfTheEvenDigets = 0;
            var values = numberToString
                .Select(x => (int)char.GetNumericValue(x))
                .ToArray();
            foreach (var number in values)
            {
                if (number % 2 == 0)
                {
                    sumOfTheEvenDigets += number;
                }
            }
            return sumOfTheEvenDigets;
        }
    }
}