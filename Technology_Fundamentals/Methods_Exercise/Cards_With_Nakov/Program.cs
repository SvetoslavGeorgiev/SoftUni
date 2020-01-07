using System;

namespace Cards_With_Nakov
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
                string[] cards =
                    {
                "2S", "2H", "2C", "2D",
                "3S", "3H", "3C", "2D",
                "4S", "4H", "4C", "4D",
                "5S", "5H", "5C", "5D",
                "6S", "6H", "6C", "6D",
                "7S", "7H", "7C", "7D",
                "8S", "8H", "8C", "8D"};
                PrintCards(cards);
                for (int i = 0; i < cards.Length; i++)
                {
                    SingleRandomSwap(i, cards);
                }
                PrintCards(cards);

        }
        private static void SingleRandomSwap(int i, string[] cards)
        {
            int randPos = rnd.Next(0, cards.Length);
            Swap(i, randPos, cards);
        }

        static void Swap(int index1, int index2, string[] cards)
        {
            string oldCard = cards[index1];
            cards[index1] = cards[index2];
            cards[index2] = oldCard;
        }

        static void PrintCards(string[] cards)
        {
            Console.WriteLine(string.Join(", ", cards));
        }
    }
}
