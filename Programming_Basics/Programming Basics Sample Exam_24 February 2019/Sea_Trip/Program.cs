using System;

namespace Sea_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForFood = double.Parse(Console.ReadLine());
            double moneyForSuvenirs = double.Parse(Console.ReadLine());
            double moneyForHotel = double.Parse(Console.ReadLine());

            double kilometersToSee = 420;
            double moneyForFuel = kilometersToSee / 100 * 7 * 1.85;

            double moneyForFoodAndSuvenirs = (moneyForFood + moneyForSuvenirs) * 3;

            double totalMoneyForHotel = (moneyForHotel * 0.85) * 3;

            double totalMoney = moneyForFoodAndSuvenirs + moneyForFuel + totalMoneyForHotel;
            Console.WriteLine($"Money needed: {totalMoney}");

        }
    }
}
