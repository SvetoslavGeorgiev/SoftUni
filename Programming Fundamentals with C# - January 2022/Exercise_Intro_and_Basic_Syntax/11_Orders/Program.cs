using System;

namespace _11_Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfOrders = int.Parse(Console.ReadLine());
           

            decimal priceForTheCoffee = 0;
            decimal totalPriceForAllOrders = 0;

            for (int i = 0; i < numberOfOrders; i++)
            {
                var pricePerCapsule = decimal.Parse(Console.ReadLine());
                var daysInMonth = int.Parse(Console.ReadLine());
                var capsuleCount = int.Parse(Console.ReadLine());
                priceForTheCoffee = (daysInMonth * capsuleCount) * pricePerCapsule;
                Console.WriteLine($"The price for the coffee is: ${priceForTheCoffee:F2}");
                totalPriceForAllOrders += priceForTheCoffee;
                priceForTheCoffee = 0;
            }
            Console.WriteLine($"Total: ${totalPriceForAllOrders:F2}");
        }
    }
}
