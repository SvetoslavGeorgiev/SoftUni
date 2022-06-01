using System;
using System.Linq;

namespace P04_Add_VAT
{
    public class P04_Add_VAT
    {
        static void Main()
        {
            var priceWithVat = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.2)
                .ToArray();

            Console.WriteLine(string.Join("\n", priceWithVat.Select(x => $"{x:F2}"))); ;
        }
    }
}
