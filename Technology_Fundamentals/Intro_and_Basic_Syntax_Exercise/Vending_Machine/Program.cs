using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            double sumOfThecoins = 0;
            while (command != "Start")
            {
                double coin = double.Parse(command);
                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    sumOfThecoins += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            var price = 0.00;
            while (command != "End")
            {
                switch (command)
                {
                    case "Nuts":
                        price = 2.0;
                        if (price > sumOfThecoins)
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        Console.WriteLine("Purchased nuts");
                        sumOfThecoins -= price;
                        break;
                    case "Water":
                        price = 0.7;
                        if (price > sumOfThecoins)
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        Console.WriteLine("Purchased water");
                        sumOfThecoins -= price;
                        break;
                    case "Crisps":
                        price = 1.5;
                        if (price > sumOfThecoins)
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        Console.WriteLine("Purchased crisps");
                        sumOfThecoins -= price;
                        break;
                    case "Soda":
                        price = 0.8;
                        if (price > sumOfThecoins)
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        Console.WriteLine("Purchased soda");
                        sumOfThecoins -= price;
                        break;
                    case "Coke":
                        price = 1.0;
                        if (price > sumOfThecoins)
                        {
                            Console.WriteLine("Sorry, not enough money");
                            break;
                        }
                        Console.WriteLine("Purchased coke");
                        sumOfThecoins -= price;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Change: {sumOfThecoins:F2}");
        }
    }
}
