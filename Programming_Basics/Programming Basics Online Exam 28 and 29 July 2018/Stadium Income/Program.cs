using System;

namespace Stadium_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectors = int.Parse(Console.ReadLine());
            int capacitetOfTheStadium = int.Parse(Console.ReadLine());
            double tiketPrice = double.Parse(Console.ReadLine());

            double totalMoney = capacitetOfTheStadium * tiketPrice;

            double moneyFromSector = totalMoney / sectors;
            double moneyForCharity = (totalMoney - (moneyFromSector * 0.75)) / 8;

            Console.WriteLine($"Total income - {totalMoney:f2} BGN" + Environment.NewLine + $"Money for charity - {moneyForCharity:f2} BGN");
        }
    }
}
