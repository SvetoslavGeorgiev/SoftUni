using System;

namespace Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            var yearTax = int.Parse(Console.ReadLine());

            var shoesPrice = yearTax * 0.60;
            var equipPrice = shoesPrice * 0.80;
            var ballPrice = equipPrice * 0.25;
            var accessories = ballPrice * 0.20;

            var totalPrice = yearTax + shoesPrice + equipPrice + ballPrice + accessories;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
