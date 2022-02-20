using System;

namespace _01_Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var totalPrice = 0.00m;
            var taxes = 0.00m;
            
            while (command != "special" && command != "regular")
            {
                var price = decimal.Parse(command);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else 
                {
                    totalPrice += price;
                    taxes += price * 0.20m;
                }

                
                command = Console.ReadLine();
            }
            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }
            var totalPricePlusTaxes = totalPrice + taxes;
            

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {totalPrice:F2}$");
            Console.WriteLine($"Taxes: {taxes:F2}$");
            Console.WriteLine("-----------");
            if (command == "special")
            {
                totalPricePlusTaxes -= totalPricePlusTaxes * 0.10m;
                Console.WriteLine($"Total price: {totalPricePlusTaxes:F2}$");
            }
            else
            {
                Console.WriteLine($"Total price: {totalPricePlusTaxes:F2}$");
            }
        }
    }
}
