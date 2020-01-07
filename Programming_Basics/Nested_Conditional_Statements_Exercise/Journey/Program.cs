using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double expenses = 0;
            
            if (budget <= 100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
            }
            else if (budget > 100 && budget <= 1000)
            {
                Console.WriteLine("Somewhere in Balkans");
            }
            else
            {
                expenses = budget * 0.90;
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"Hotel - {expenses:F2}");
            }
            if (season == "summer" && budget <= 100)
            {
                expenses = budget * 0.30;
                Console.WriteLine($"Camp - {expenses:F2}");
            }
            else if (season == "summer" && budget > 100 && budget <= 1000)
            {
                expenses = budget * 0.40;
                Console.WriteLine($"Camp - {expenses:F2}");
            }
            else if (season == "winter" && budget <= 100)
            {
                expenses = budget * 0.70;
                Console.WriteLine($"Hotel - {expenses:F2}");
            }
            else if (season == "winter" && budget > 100 && budget <= 1000)
            {
                expenses = budget * 0.80;
                Console.WriteLine($"Hotel - {expenses:F2}");
            }
        }
    }
}
