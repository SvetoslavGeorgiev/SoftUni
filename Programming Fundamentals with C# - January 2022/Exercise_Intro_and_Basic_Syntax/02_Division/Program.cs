using System;

namespace _02_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var integer = int.Parse(Console.ReadLine());

            var devider = -1;

            if (integer % 10 == 0)
            {
                devider = 10;
            }
            else if (integer % 7 == 0)
            {
                devider = 7;
            }
            else if (integer % 6 == 0)
            {
                devider = 6;
            }
            else if (integer % 3 == 0)
            {
                devider = 3;
            }
            else if (integer % 2 == 0)
            {
                devider = 2;
            }
            if (devider <= 0)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
                Console.WriteLine($"The number is divisible by {devider}");
            }

        }
    }
}
