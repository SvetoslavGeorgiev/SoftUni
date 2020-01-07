using System;
using System.Linq;

namespace Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string commandString = Console.ReadLine();
            while (commandString != "END")
            {
                bool isPalindromeInteger = IsPalindrome(commandString);

                if (isPalindromeInteger)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                commandString = Console.ReadLine();
            }
        }

        private static bool IsPalindrome(string commandString)
        {
            char[] arr = commandString.ToCharArray();
            Array.Reverse(arr);

            string temp = new string(arr);

            if (temp == commandString)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
