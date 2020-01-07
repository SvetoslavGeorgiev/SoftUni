using System;

namespace Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            var pounds = double.Parse(Console.ReadLine());

            var dollars = pounds * 1.31;

            Console.WriteLine($"{dollars:F3}");
        }
    }
}
