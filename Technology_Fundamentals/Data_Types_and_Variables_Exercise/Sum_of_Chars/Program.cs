using System;

namespace Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sumOfTheAscii = 0;

            for (int i = 1; i <= n; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());

                int currentCharAscii = currentChar;

                sumOfTheAscii += currentCharAscii;
            }
            Console.WriteLine($"The sum equals: {sumOfTheAscii}");
        }
    }
}
