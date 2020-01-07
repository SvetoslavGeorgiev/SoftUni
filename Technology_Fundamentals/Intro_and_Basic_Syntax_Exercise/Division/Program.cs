using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            bool divisible = false;
            var divisibleOnNumber = 0;


            if (number % 10 == 0)
            {
                divisible = true;
                divisibleOnNumber = 10;
            }
            else if (number % 7 == 0)
            {
                divisible = true;
                divisibleOnNumber = 7;
            }
            else if (number % 6 == 0)
            {
                divisible = true;
                divisibleOnNumber = 6;
            }
            else if (number % 3 == 0)
            {
                divisible = true;
                divisibleOnNumber = 3;
            }
            else if (number % 2 == 0)
            {
                divisible = true;
                divisibleOnNumber = 2;
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
            if (divisible == true)
            {
                Console.WriteLine($"The number is divisible by {divisibleOnNumber}");
            }
        }
    }
}
