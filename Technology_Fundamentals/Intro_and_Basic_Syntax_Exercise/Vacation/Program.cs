using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var kindOfThePeople = Console.ReadLine();
            var dayOfTheWeek = Console.ReadLine();

            double price = 0;
            double totalPrice = 0;

            if (kindOfThePeople == "Students")
            {
                if (dayOfTheWeek == "Friday")
                {
                    price = 8.45;
                }
                else if (dayOfTheWeek == "Saturday")
                {
                    price = 9.80;
                }
                else if (dayOfTheWeek == "Sunday")
                {
                    price = 10.46;
                }
                if (numberOfPeople >= 30)
                {
                    totalPrice = price * numberOfPeople * 0.85;
                }
                else
                {
                    totalPrice = price * numberOfPeople;
                }
            }
            else if (kindOfThePeople == "Business")
            {
                if (dayOfTheWeek == "Friday")
                {
                    price = 10.90;
                }
                else if (dayOfTheWeek == "Saturday")
                {
                    price = 15.60;
                }
                else if (dayOfTheWeek == "Sunday")
                {
                    price = 16.00;
                }
                if (numberOfPeople >= 100)
                {
                    totalPrice = (price * numberOfPeople) - (10 * price);
                }
                else
                {
                    totalPrice = price * numberOfPeople;
                }
            }
            else if (kindOfThePeople == "Regular")
            {
                if (dayOfTheWeek == "Friday")
                {
                    price = 15.00;
                }
                else if (dayOfTheWeek == "Saturday")
                {
                    price = 20.00;
                }
                else if (dayOfTheWeek == "Sunday")
                {
                    price = 22.50;
                }
                if (numberOfPeople >= 10 && numberOfPeople <= 20)
                {
                    totalPrice = price * numberOfPeople * 0.95;
                }
                else
                {
                    totalPrice = price * numberOfPeople;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
