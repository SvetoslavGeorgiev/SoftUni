using System;

namespace NewHouse2
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double priceFlower = 0;

            switch (flower)
            {
                case "Roses":
                    priceFlower = 5;
                    break;
                case "Dahlias":
                    priceFlower = 3.80;
                    break;
                case "Tulips":
                    priceFlower = 2.80;
                    break;
                case "Narcissus":
                    priceFlower = 3;
                    break;
                case "Gladiolus":
                    priceFlower = 2.50;
                    break;
            }

            double totalPrice = numberOfFlowers * priceFlower;

            if (numberOfFlowers > 80 && flower == "Roses")
            {
                totalPrice = totalPrice - (totalPrice * 0.10);
            }
            else if (numberOfFlowers > 90 && flower == "Dahlias")
            {
                totalPrice = totalPrice - (totalPrice * 0.15);
            }
            else if (numberOfFlowers > 80 && flower == "Tulips")
            {
                totalPrice = totalPrice - (totalPrice * 0.15);
            }
            else if (numberOfFlowers < 120 && flower == "Narcissus")
            {
                totalPrice = totalPrice + (totalPrice * 0.15);
            }
            else if (numberOfFlowers < 80 && flower == "Gladiolus")
            {
                totalPrice = totalPrice + (totalPrice * 0.20);
            }

            if (totalPrice > budget)
            {
                Console.WriteLine($"Not enough money, you need {totalPrice - budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {flower} and {budget - totalPrice:f2} leva left.");
            }
        }
    }
}