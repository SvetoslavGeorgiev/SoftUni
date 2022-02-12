using System;
using System.Linq;


namespace _06_Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var secondPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (firstPlayerCards.Any() && secondPlayerCards.Any())
            {
                var count = Math.Min(firstPlayerCards.Count, secondPlayerCards.Count);
                for (int i = 0; i < count; i++)
                {
                    if (firstPlayerCards[i] > secondPlayerCards[i])
                    {
                        firstPlayerCards.Add(firstPlayerCards[i]);
                        firstPlayerCards.Add(secondPlayerCards[i]);
                        firstPlayerCards.RemoveAt(i);
                        secondPlayerCards.RemoveAt(i);
                    }
                    else if (firstPlayerCards[i] < secondPlayerCards[i])
                    {
                        secondPlayerCards.Add(secondPlayerCards[i]);
                        secondPlayerCards.Add(firstPlayerCards[i]);
                        firstPlayerCards.RemoveAt(i);
                        secondPlayerCards.RemoveAt(i);
                    }
                    else
                    {
                        firstPlayerCards.RemoveAt(i);
                        secondPlayerCards.RemoveAt(i);
                    }
                    count--;
                    i = -1;
                }
            }
            if (firstPlayerCards.Count != 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerCards.Sum()}");
            }
            if (secondPlayerCards.Count != 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerCards.Sum()}");
            }
        }
    }
}