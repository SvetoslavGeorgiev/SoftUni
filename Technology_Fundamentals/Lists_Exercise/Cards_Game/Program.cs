using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> cardsOfTheFirstPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> cardsOfTheSecondPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int theBigestDeck = Math.Max(cardsOfTheSecondPlayer.Count, cardsOfTheFirstPlayer.Count);
            int totalCards = cardsOfTheFirstPlayer.Count + cardsOfTheSecondPlayer.Count;

            for (int i = 0; i < theBigestDeck; i++)
            {
                while (theBigestDeck != totalCards)
                {
                    if (cardsOfTheFirstPlayer[i] > cardsOfTheSecondPlayer[i])
                    {
                        cardsOfTheFirstPlayer.Add(cardsOfTheFirstPlayer[i]);
                        cardsOfTheFirstPlayer.Add(cardsOfTheSecondPlayer[i]);
                        cardsOfTheFirstPlayer.RemoveAt(i);
                        cardsOfTheSecondPlayer.RemoveAt(i);
                    }
                    else if (cardsOfTheFirstPlayer[i] < cardsOfTheSecondPlayer[i])
                    {
                        cardsOfTheSecondPlayer.Add(cardsOfTheSecondPlayer[i]);
                        cardsOfTheSecondPlayer.Add(cardsOfTheFirstPlayer[i]);
                        cardsOfTheFirstPlayer.RemoveAt(i);
                        cardsOfTheSecondPlayer.RemoveAt(i);
                    }
                    else
                    {
                        cardsOfTheFirstPlayer.RemoveAt(i);
                        cardsOfTheSecondPlayer.RemoveAt(i);
                        totalCards = totalCards - 2;
                    }
                    i = 0;
                    theBigestDeck = Math.Max(cardsOfTheSecondPlayer.Count, cardsOfTheFirstPlayer.Count);
                }
            }
            if (cardsOfTheFirstPlayer.Count > cardsOfTheSecondPlayer.Count)
            {
                
                Console.WriteLine($"First player wins! Sum: {cardsOfTheFirstPlayer.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {cardsOfTheSecondPlayer.Sum()}");
            }
        }
    }
}
