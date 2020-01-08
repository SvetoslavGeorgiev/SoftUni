using System;
using System.Linq;
using System.Text;

namespace Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToList();


            StringBuilder firstString = new StringBuilder(input[0]);
            StringBuilder secondString = new StringBuilder(input[1]);
            

            int sum = TotalSumOFMultipliedChars(firstString, secondString);

            Console.WriteLine(sum);
        }

        private static int TotalSumOFMultipliedChars(StringBuilder firstString, StringBuilder secondString)
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
