using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int collums = int.Parse(Console.ReadLine());

            double premiere = 12.00;
            double normal = 7.50;
            double dicount = 5.00;
            double moneyFromTickets = 0;

            if (type == "Premiere")
            {
                moneyFromTickets = premiere * rows * collums;
                Console.WriteLine($"{moneyFromTickets:F2}");
                Console.WriteLine("leva");
            }
            else if (type == "Normal")
            {
                moneyFromTickets = normal * rows * collums;
                Console.WriteLine($"{moneyFromTickets:F2}");
                Console.WriteLine("leva");
            }
            else if (type == "Discount")
            {
                moneyFromTickets = dicount * rows * collums;
                Console.WriteLine($"{moneyFromTickets:F2} leva");
            }
        }
    }
}
