using System;
using System.Linq;

namespace _02_Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var raceEnd = input.Count / 2;

            var leftTime = 0.00;
            var rightTime = 0.00;
            var isLess = true;

            for (int i = 0; i < raceEnd; i++)
            {
                var currentLeftTime = input[i];
                var currentRightTime = input[input.Count - 1 - i];

                var result =  Calculation(currentLeftTime, leftTime);
                leftTime = result;
                var resultRight = Calculation(currentRightTime, rightTime);
                rightTime = resultRight;
                if (rightTime < leftTime)
                {
                    isLess = false;
                }
                else
                {
                    isLess = true;
                }
            }
            if (isLess)
            {
                Console.WriteLine($"The winner is left with total time: {leftTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightTime}");
            }
        }

        private static double Calculation(int currentTime, double totalTime)
        {
            
            if (currentTime != 0)
            {
                totalTime += currentTime;
            }
            else
            {
                totalTime = Math.Round((totalTime * 0.8), 2);
            }

            return totalTime;
        }
    }
}
