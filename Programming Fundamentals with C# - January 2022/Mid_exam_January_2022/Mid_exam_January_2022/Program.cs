using System;

namespace Mid_exam_January_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfcities = int.Parse(Console.ReadLine());
            var totalProfit = 0.00m;

            for (int i = 1; i <= numberOfcities; i++)
            {
                var city = Console.ReadLine();

                var earnedMoney = decimal.Parse(Console.ReadLine());

                var expenses = decimal.Parse(Console.ReadLine());


                if (i % 3 == 0 && i % 5 != 0)
                {
                    expenses += expenses * 0.5m;
                }
                if (i % 5 == 0)
                {
                    earnedMoney -= earnedMoney * 0.1m;
                }

                var dayProffit = earnedMoney - expenses;
                Console.WriteLine($"In {city} Burger Bus earned {dayProffit:F2} leva.");
                totalProfit += dayProffit;
            }

            Console.WriteLine($"Burger Bus total profit: {totalProfit:F2} leva.");
        }
    }
}
