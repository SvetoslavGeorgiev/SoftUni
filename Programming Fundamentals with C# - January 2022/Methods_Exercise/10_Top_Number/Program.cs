using System;

namespace _10_Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine();

            bool isSumOfItDigitDevisibleByEight = IsSumOfItDigitDevisibleByEight(number);
            bool holdAtleastOneOddDigit = HoldAtleastOneOddDigit(number);
            PrintTheTopNumbers(int.Parse(number));
        }

        private static void PrintTheTopNumbers(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (HoldAtleastOneOddDigit(i.ToString()) && IsSumOfItDigitDevisibleByEight(i.ToString()))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool HoldAtleastOneOddDigit(string number)
        {
            bool result = false;
            var digit = 0;
            foreach (char ch in number.ToCharArray())
            {
                digit = int.Parse(ch.ToString());
                if (digit % 2 == 1)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private static bool IsSumOfItDigitDevisibleByEight(string number)
        {
            bool result = false;
            var sum = 0;
            foreach (char digit in number.ToCharArray())
            {
                sum += int.Parse(digit.ToString());
            }
            if (sum % 8 == 0)
            {
                result = true;
            }
            return result;
        }
    }
}
