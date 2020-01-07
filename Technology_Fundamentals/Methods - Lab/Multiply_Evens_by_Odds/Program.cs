using System;
using System.Linq;

namespace Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);
            
            int sumOfEvensNumbers = GetSumOfEvenDigits(number);
            int sumOfOddsNumbers = GetSumOfOddDigits(number);
            int result = GetMultipleOfEvenAndOdds(sumOfEvensNumbers, sumOfOddsNumbers);
            Console.WriteLine(result);
        }

        private static int GetMultipleOfEvenAndOdds(int sumOfEvensNumbers, int sumOfOddsNumbers)
        {
            int result = sumOfEvensNumbers * sumOfOddsNumbers;
            return result;
        }

        private static int GetSumOfOddDigits(int number)
        {
            int[] arr = number.ToString()
                .ToCharArray()
                .Select(x => (int)Char.GetNumericValue(x))
                .ToArray();
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    result += arr[i];
                }
                else
                {
                    result += 0;
                }
            }
            return result;
        }

        private static int GetSumOfEvenDigits(int number)
        {
            int[] arr = number.ToString()
                .ToCharArray()
                .Select(x => (int)Char.GetNumericValue(x))
                .ToArray();
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    result += arr[i];
                }
                else
                {
                    result += 0;
                }
            }
            return result;
        }
    }
}
