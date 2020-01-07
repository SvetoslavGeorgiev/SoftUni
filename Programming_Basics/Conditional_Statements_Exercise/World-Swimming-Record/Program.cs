using System;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double lenth = double.Parse(Console.ReadLine());
            double timeForOneMeter = double.Parse(Console.ReadLine());

            double time =(lenth * timeForOneMeter);
            double resistenOfWater = Math.Floor(lenth / 15);
            double slowingDown =resistenOfWater * 12.5;
            double finalTime = time + slowingDown;
            double deferenceBetweenTheTimes = finalTime - record;

            if (record > finalTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {finalTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {deferenceBetweenTheTimes:F2} seconds slower.");
            }

        }
    }
}
