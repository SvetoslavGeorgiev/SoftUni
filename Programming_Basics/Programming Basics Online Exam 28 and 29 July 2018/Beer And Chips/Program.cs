using System;

namespace Beer_And_Chips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beers = int.Parse(Console.ReadLine());
            int chipses = int.Parse(Console.ReadLine());

            double beerPrice = 1.20;
            double moneyForBeer = beerPrice * beers;

            double chipsPrice = moneyForBeer * 0.45;
            double moneyForChips = Math.Ceiling(chipsPrice * chipses);

            double moneyNeeded = moneyForBeer + moneyForChips;

            if (budget >= moneyNeeded)
            {
                Console.WriteLine($"{name} bought a snack and has {budget - moneyNeeded:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {moneyNeeded - budget:f2} more leva!");
            }
        }
    }
}
