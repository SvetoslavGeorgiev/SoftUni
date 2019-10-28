using System;

namespace Trip_To_World_Cup
{
    class Program
    {
        static void Main(string[] args)
        {
            double planeTiketGoingPrice = double.Parse(Console.ReadLine());
            double planeTiketComeBackPrice = double.Parse(Console.ReadLine());
            double tikitPrice = double.Parse(Console.ReadLine());
            int games = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double totalPlaneTiketPrice = (planeTiketComeBackPrice + planeTiketGoingPrice) * 6;
            double planeTiketPriceAfterDiscount = (100 - discount) / 100 * totalPlaneTiketPrice;
            double momeyForAllGames = 6 * tikitPrice * games;

            double neededMoney = planeTiketPriceAfterDiscount + momeyForAllGames;
            double moneyForEachOneOFThem = neededMoney / 6;

            Console.WriteLine($"Total sum: {neededMoney:f2} lv." 
                + Environment.NewLine 
                + $"Each friend has to pay {moneyForEachOneOFThem:f2} lv.");
        }
    }
}
