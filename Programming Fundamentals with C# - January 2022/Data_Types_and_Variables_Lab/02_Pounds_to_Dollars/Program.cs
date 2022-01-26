using System;

namespace _02_Pounds_to_Dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pounds = decimal.Parse(Console.ReadLine());

            decimal dollars = pounds * 1.31m;

            Console.WriteLine($"{dollars:F3}");
        }
    }
}
