using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double weekendsAtHome = double.Parse(Console.ReadLine());

            double weekendsInSofia = 48 - weekendsAtHome;
            double gamesInSodfia = weekendsInSofia * 3 / 4;
            double holidayGames = holidays * 2 / 3;
            double totalGames = weekendsAtHome + gamesInSodfia + holidayGames;
            double games = (totalGames * 0.15) + totalGames;

            if (year == "leap")
            {
                Console.WriteLine(Math.Floor(games));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Floor(totalGames));
            }
        }
    }
}
