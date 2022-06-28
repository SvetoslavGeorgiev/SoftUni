namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            var coins = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var sum = int.Parse(Console.ReadLine());

            var selectedCoins = ChooseCoins(coins, sum);


            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var coin in selectedCoins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }

        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {

            var sortedCoins = coins.OrderByDescending(x => x).ToArray();

            var chosenCoins = new Dictionary<int, int>();

            var currentSum = 0;
            var coinIndex = 0;

            while (currentSum != targetSum && coinIndex < sortedCoins.Length)
            {

                var currentCoinValue = sortedCoins[coinIndex];


                var diff = targetSum - currentSum;

                var numberOfCoins = diff / currentCoinValue;

                if (currentSum + currentCoinValue <= targetSum)
                {
                    chosenCoins.Add(currentCoinValue, numberOfCoins);


                    currentSum += numberOfCoins * currentCoinValue;


                }

                coinIndex++;


            }

            if (currentSum != targetSum)
            {
                throw new InvalidOperationException();
            }
            return chosenCoins;
        }
    }
}