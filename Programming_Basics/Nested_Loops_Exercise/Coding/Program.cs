using System;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            for (int printTime = number.Length - 1; printTime >= 0; printTime--)
            {
                char currentDigit = number[printTime];
                int currentDigitToNum = int.Parse(currentDigit.ToString());

                if (currentDigitToNum == 0)
                {
                    Console.WriteLine("ZERO");
                    continue;
                }
                for (int i = 1; i <= currentDigitToNum; i++)
                {
                    Console.Write((char)(currentDigitToNum + 33));
                }
                Console.WriteLine();
            }
        }
    }
}
