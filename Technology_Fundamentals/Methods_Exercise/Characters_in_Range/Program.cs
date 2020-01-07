using System;

namespace Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintAllCharsBetwinTwoGiven(firstChar, secondChar);
        }

        private static void PrintAllCharsBetwinTwoGiven(char firstChar, char secondChar)
        {
            if (firstChar < secondChar)
            {
                for (char i = firstChar; i < secondChar; i++)
                {
                    if (i != firstChar)
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
            else if (secondChar < firstChar)
            {
                for (char i = secondChar; i < firstChar; i++)
                {
                    if (i != secondChar)
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
        }
    }
}
