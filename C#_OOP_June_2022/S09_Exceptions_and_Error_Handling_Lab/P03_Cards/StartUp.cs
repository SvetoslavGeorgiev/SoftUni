namespace P03_Cards
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(", ");

            var cards = new List<Card>();

            for (int i = 0; i < input.Length; i++)
            {
                var cardInfo = input[i].Split(" ");
                var face = cardInfo[0];
                var suit = cardInfo[1];

                try
                {
                    var newCard = new Card(face, suit);
                    cards.Add(newCard);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    if (i == input.Length - 1)
                    {

                        Console.WriteLine(string.Join(" ", cards));

                    }
                }


            }


        }
    }


    public class Card
    {
        private Dictionary<string, string> cardFace = new Dictionary<string, string>
        {
                {"2", "2" },
                {"3", "3" },
                {"4", "4" },
                {"5", "5" },
                {"6", "6" },
                {"7", "7" },
                {"8", "8" },
                {"9", "9" },
                {"10", "10" },
                {"J", "J" },
                {"Q", "Q" },
                {"K", "K" },
                {"A", "A" },
        };

        private Dictionary<string, string> cardSuit = new Dictionary<string, string>
        {
                {"S", "\u2660" },
                {"H", "\u2665" },
                {"D", "\u2666" },
                {"C", "\u2663" }
        };

        private string face;
        private string suit;


        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }


        public string Face
        {
            get => face;
            private set
            {
                if (!cardFace.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }
        public string Suit
        {
            get => suit;
            private set
            {
                if (!cardSuit.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                suit = value;
            }
        }


        public override string ToString()
        {
            return $"[{cardFace[Face]}{cardSuit[Suit]}]";
        }
    }
}
