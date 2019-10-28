using System;

namespace Orders
{
    class Program
    {
        static double orderPrice = 0;
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            int quantity = int.Parse(Console.ReadLine());

            calculation(product, quantity);
            PrintOrderPrice();
        }

        

        static void calculation(string product, int quantity)
        {
            
            if (product == "water")
            {
                orderPrice = 1.00 * quantity;
            }
            else if (product == "coffee")
            {
                orderPrice = 1.50 * quantity;
            }
            else if (product == "coke")
            {
                orderPrice = 1.40 * quantity;
            }
            else if (product == "snacks")
            {
                orderPrice = 2.00 * quantity;
            }
        }
        private static void PrintOrderPrice()
        {
            Console.WriteLine($"{orderPrice:F2}");
        }
    }
}
