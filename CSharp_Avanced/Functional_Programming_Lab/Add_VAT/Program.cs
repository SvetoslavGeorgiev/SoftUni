using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceWithVat = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x =>x * 1.2)
                .ToList();

            foreach (var price in priceWithVat)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
