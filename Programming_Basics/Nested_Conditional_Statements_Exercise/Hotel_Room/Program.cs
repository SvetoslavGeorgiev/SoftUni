using System;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            decimal priceStudio = 0;
            decimal priceApartment = 0;
            decimal holidayPriceForStudio = 0;
            decimal holidayPriceForApartment = 0;

            switch (month)
            {
                case "May":
                case "October":
                    priceStudio = 50;
                    priceApartment = 65;
                    break;
                case "June":
                case "September":
                    priceStudio = 75.20M;
                    priceApartment = 68.70M;
                    break;
                case "July":
                case "August":
                    priceStudio = 76;
                    priceApartment = 77;
                    break;
            }
            holidayPriceForApartment = priceApartment * nights;
            holidayPriceForStudio = priceStudio * nights;

            if (nights > 7 && nights <= 14 && month == "May" || 
                nights > 7 && nights <= 14 && month == "October")
            {
                holidayPriceForStudio = holidayPriceForStudio * 0.95M;
            }
            else if (nights > 14 && month == "May" || nights > 14 && month == "October")
            {
                holidayPriceForStudio = holidayPriceForStudio * 0.70M;
            }
            else if (nights > 14 && month == "June" || nights > 14 && month == "September")
            {
                holidayPriceForStudio = holidayPriceForStudio * 0.80M;
            }
            if (nights > 14)
            {
                holidayPriceForApartment = holidayPriceForApartment * 0.90M;
            }
            Console.WriteLine($"Apartment: {holidayPriceForApartment:F2} lv.");
            Console.WriteLine($"Studio: {holidayPriceForStudio:F2} lv.");
        }
    }
}
