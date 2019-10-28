using System;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            double butget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double people = double.Parse(Console.ReadLine());

            double priceOfTheBoat = 0;
            double priceAfterDiscount = 0;

            switch (season)
            {
                case "Spring":
                    priceOfTheBoat = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    priceOfTheBoat = 4200;
                    break;
                case "Winter":
                    priceOfTheBoat = 2600;
                    break;
            }
            if (people <= 6 && people % 2 == 0 && season != "Autumn")
            {
                priceAfterDiscount = priceOfTheBoat * 0.90;
                priceAfterDiscount = priceAfterDiscount * 0.95;
            }
            else if (people > 6 && people <= 11 && people % 2 == 0 && season != "Autumn")
            {
                priceAfterDiscount = priceOfTheBoat * 0.85;
                priceAfterDiscount = priceAfterDiscount * 0.95;
            }
            else if (people > 11 && people % 2 == 0 && season != "Autumn")
            {
                priceAfterDiscount = priceOfTheBoat * 0.75;
                priceAfterDiscount = priceAfterDiscount * 0.95;
            }
            else if (people <= 6)
            {
                priceAfterDiscount = priceOfTheBoat * 0.90;
            }
            else if (people > 6 && people <= 11)
            {
                priceAfterDiscount = priceOfTheBoat * 0.85;
            }
            else if (people > 11)
            {
                priceAfterDiscount = priceOfTheBoat * 0.75;
            }

            if (butget >= priceAfterDiscount)
            {
                Console.WriteLine($"Yes! You have {butget - priceAfterDiscount:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {priceAfterDiscount - butget:F2} leva.");
            }
        }
    }
}
