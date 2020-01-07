using System;

namespace Coins2
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());

            int cakeVolume = cakeLength * cakeWidth;
            int pieceVolume = 1 * 1;
            int amoundOfPieces = cakeVolume / pieceVolume;

            string piecesEaten = string.Empty;
            string stopEat = "STOP";
            bool stop = false;

            while (amoundOfPieces >= 0)
            {
                piecesEaten = Console.ReadLine();
                if (piecesEaten == stopEat)
                {
                    stop = true;
                    break;
                }
                int numberOFPieces = int.Parse(piecesEaten);
                amoundOfPieces -= numberOFPieces;
                if (amoundOfPieces < 0)
                {
                    break;
                }
                
            }
            if (stop == true)
            {
                Console.WriteLine($"{amoundOfPieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! " +
                    $"You need {Math.Abs(amoundOfPieces)} pieces more.");
            }
        }
    }
}
