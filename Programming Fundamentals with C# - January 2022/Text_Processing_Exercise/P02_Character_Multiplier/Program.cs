using System;
using System.Linq;

namespace P02_Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .ToList();


            var firstString = input[0];
            var secondString = input[1];

            int sum = TotalSumOFMultipliedChars(firstString, secondString);

            Console.WriteLine(sum);
        }

        private static int TotalSumOFMultipliedChars(string firstString, string secondString)
        {
            var result = 0;
            var length = 0;

            if (firstString.Length >= secondString.Length)
            {
                length = secondString.Length;
            }
            else
            {
                length = firstString.Length;
            }


            for (int i = 0; i < length; i++)
            {
                result += firstString[i] * secondString[i];
            }

            if (length == firstString.Length)
            {
                for (int i = length; i < secondString.Length; i++)
                {
                    result += secondString[i];
                }
            }
            else
            {
                for (int i = length; i < firstString.Length; i++)
                {
                    result += firstString[i];
                }
            }

            return result;
        }
    }
}
