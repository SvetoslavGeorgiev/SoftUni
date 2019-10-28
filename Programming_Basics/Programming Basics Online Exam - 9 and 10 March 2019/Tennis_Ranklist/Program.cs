using System;

namespace Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            var turnirs = int.Parse(Console.ReadLine());
            var startPoints = int.Parse(Console.ReadLine());

            var winPoints = 0.00;
            var points = 0.00;
            var wins = 0.00;
            for (int i = 1; i <= turnirs; i++)
            {
                var etap = Console.ReadLine();

                switch (etap)
                {
                    case "W":
                        points = 2000;
                        winPoints += points;
                        wins++;
                        break;
                    case "F":
                        points = 1200;
                        winPoints += points;
                        break;
                    case "SF":
                        points = 720;
                        winPoints += points;
                        break;
                }

            }
            Console.WriteLine($"Final points: {startPoints + winPoints}");
            Console.WriteLine($"Average points: {Math.Floor(winPoints / turnirs)}");
            Console.WriteLine($"{(wins / turnirs) * 100:F2}%");
        }
    }
}
