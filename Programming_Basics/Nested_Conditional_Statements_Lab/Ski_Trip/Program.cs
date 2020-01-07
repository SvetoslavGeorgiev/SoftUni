using System;

namespace Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string grade = Console.ReadLine();

            double nights = days - 1;
            double price = 0;

            if (room == "room for one person")
            {
                price = nights * 18;
            }
            else if (room == "apartment" && days < 10)
            {
                price = nights * 25;
                price = price * 0.70;
            }
            else if (room == "apartment" && days >= 10 && days <= 15)
            {
                price = nights * 25;
                price = price * 0.65;
            }
            else if (room == "apartment" && days > 15)
            {
                price = nights * 25;
                price = price * 0.50;
            }
            else if (room == "president apartment" && days < 10)
            {
                price = nights * 35;
                price = price * 0.90;
            }
            else if (room == "president apartment" && days >= 10 && days <= 15)
            {
                price = nights * 35;
                price = price * 0.85;
            }
            else if (room == "president apartment" && days > 15)
            {
                price = nights * 35;
                price = price * 0.80;
            }
            if (grade == "positive")
            {
                price = price * 1.25;
            }
            else if (grade == "negative")
            {
                price = price * 0.90;
            }
            Console.WriteLine($"{price:F2}");
        }
    }
}
