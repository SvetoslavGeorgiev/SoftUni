using System;

namespace Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = -1.0;

            if (dayOfTheWeek == "Monday" ||
                dayOfTheWeek == "Tuesday" ||
                dayOfTheWeek == "Wednesday" ||
                dayOfTheWeek == "Thursday" ||
                dayOfTheWeek == "Friday")
            {
                if (product == "banana")
                {
                    price = 2.50;
                }
                else if (product == "apple")
                {
                    price = 1.20;
                }
                else if (product == "orange")
                {
                    price = 0.85;
                }
                else if (product == "grapefruit")
                {
                    price = 1.45;
                }
                else if (product == "kiwi")
                {
                    price = 2.70;
                }
                else if (product == "pineapple")
                {
                    price = 5.50;
                }
                else if (product == "grapes")
                {
                    price = 3.85;
                }
            }
            else if (dayOfTheWeek == "Saturday" || dayOfTheWeek == "Sunday")
            {
                if (product == "banana")
                {
                    price = 2.70;
                }
                else if (product == "apple")
                {
                    price = 1.25;
                }
                else if (product == "orange")
                {
                    price = 0.90;
                }
                else if (product == "grapefruit")
                {
                    price = 1.60;
                }
                else if (product == "kiwi")
                {
                    price = 3.00;
                }
                else if (product == "pineapple")
                {
                    price = 5.60;
                }
                else if (product == "grapes")
                {
                    price = 4.20;
                }
            }
            if (price >= 0)
            {
                Console.WriteLine($"{quantity * price:F2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
