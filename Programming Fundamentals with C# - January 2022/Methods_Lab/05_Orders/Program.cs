using System;

namespace _05_Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = Console.ReadLine();
            var quantity = int.Parse(Console.ReadLine());

            double totalPriceOfTheOrder = GettingTheOrderValue(order, quantity);

            Console.WriteLine($"{totalPriceOfTheOrder:F2}");
        }

        private static double GettingTheOrderValue(string order, int quantity)
        {
            var totalPrice = 0.00;

            switch (order)
            {
                case "coffee":
                    totalPrice = quantity * 1.50;
                    break;
                case "water":
                    totalPrice = quantity * 1.00;
                    break;
                case "coke":
                    totalPrice = quantity * 1.40;
                    break;
                case "snacks":
                    totalPrice = quantity * 2.00;
                    break;
                default:
                    break;
            }

            return totalPrice;
        }
    }
}
