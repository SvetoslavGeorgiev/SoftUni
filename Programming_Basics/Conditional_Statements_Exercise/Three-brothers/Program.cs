using System;

namespace Three_brothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double timeOfFirstBrother = double.Parse(Console.ReadLine());
            double timeOfSecondBeother = double.Parse(Console.ReadLine());
            double timeOfThirdBrother = double.Parse(Console.ReadLine());
            double timeFatherNeed = double.Parse(Console.ReadLine());

            double timeForClining = 1/ (1 / timeOfFirstBrother + 1 / timeOfSecondBeother + 1 / timeOfThirdBrother);
            double timeForCliningPlusRest =(timeForClining * 0.15) + timeForClining;

            double surprise =timeFatherNeed - timeForCliningPlusRest;
            double surpriseAbs = Math.Abs(surprise);

            if (surprise >= 0)
            {
                Console.WriteLine($"Cleaning time: {timeForCliningPlusRest:F2}");
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(surprise)} hours.");
            }
            else
            {
                Console.WriteLine($"Cleaning time: {timeForCliningPlusRest:F2}");
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(surpriseAbs)} hours.");
            }
        }
    }
}
