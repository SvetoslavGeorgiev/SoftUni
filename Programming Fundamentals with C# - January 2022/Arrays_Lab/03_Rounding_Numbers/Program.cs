using System;
using System.Linq;

namespace _03_Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            foreach (var number in numbers)
            {

                Console.WriteLine($"{(decimal)number} => {Math.Round((decimal)number, MidpointRounding.AwayFromZero)}");

            }
        }
    }
}
