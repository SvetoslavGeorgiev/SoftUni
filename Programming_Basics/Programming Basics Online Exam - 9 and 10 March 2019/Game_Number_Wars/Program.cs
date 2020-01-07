using System;

namespace Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameOfFirstPlayer = Console.ReadLine();
            var nameOfSecondPlayer = Console.ReadLine();

            var firstPlayerPoint = 0;
            var secondPlayerPoints = 0;

            while (true)
            {
                var firstCard = Console.ReadLine();
                if (firstCard == "End of game")
                {
                    break;
                }
                var firstCardNumber = int.Parse(firstCard);
                var secondCardNumber = int.Parse(Console.ReadLine());

                if (firstCardNumber > secondCardNumber)
                {
                    firstPlayerPoint += (firstCardNumber - secondCardNumber);
                }
                else if (secondCardNumber > firstCardNumber)
                {
                    secondPlayerPoints += (secondCardNumber - firstCardNumber);
                }
                else
                {
                    Console.WriteLine("Number wars!");
                    firstCardNumber = int.Parse(Console.ReadLine());
                    secondCardNumber = int.Parse(Console.ReadLine());

                    if (firstCardNumber > secondCardNumber)
                    {
                        Console.WriteLine($"{nameOfFirstPlayer} is winner with {firstPlayerPoint} points");
                    }
                    else
                    {
                        Console.WriteLine($"{nameOfSecondPlayer} is winner with {secondPlayerPoints} points");
                    }
                    return;
                }
            }
            Console.WriteLine($"{nameOfFirstPlayer} has {firstPlayerPoint} points");
            Console.WriteLine($"{nameOfSecondPlayer} has {secondPlayerPoints} points");
        }
    }
}
