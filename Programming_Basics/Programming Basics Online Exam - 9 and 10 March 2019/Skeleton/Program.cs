using System;

namespace Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var minutes = int.Parse(Console.ReadLine());
            var seconds = int.Parse(Console.ReadLine());
            var lenght = double.Parse(Console.ReadLine());
            var secondsFor100Meters = int.Parse(Console.ReadLine());

            var totalSeconds = minutes * 60 + seconds;
            var slowdownSeconds = (lenght / 120) * 2.5;
            var marinTime = (lenght / 100) * secondsFor100Meters - slowdownSeconds;

            if (marinTime <= totalSeconds)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!" + Environment.NewLine + $"His time is {marinTime:F3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {Math.Abs(totalSeconds - marinTime):F3} second slower.");
            }
        }
    }
}
