using System;

namespace _09_Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = string.Empty;
            IsPalindromeOrNot(number);
        }

        private static void IsPalindromeOrNot(string number)
        {
            while ((number = Console.ReadLine()) != "END")
            {
                var currentNumber = int.Parse(number);
                var arr = number.ToCharArray();
                Array.Reverse(arr);
                var reversedString = new string(arr);
                var reversedNumber = int.Parse(reversedString);
                if (reversedNumber == currentNumber)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
