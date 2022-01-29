using System;
using System.Numerics;

namespace _11_Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfSnowballs = int.Parse(Console.ReadLine());

            BigInteger snowBallValue = 0;
            var forPrintingSnowballSnow = 0;
            var forPrintingSnowballTime = 0;
            var forPrintingSnowballQuality = 0;

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                var snowballSnow = int.Parse(Console.ReadLine());
                var snowballTime = int.Parse(Console.ReadLine());
                var snowballQuality = int.Parse(Console.ReadLine());

                
                if (snowballTime != 0)
                {
                    BigInteger currentsSnowBallValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                    if (currentsSnowBallValue >= snowBallValue)
                    {
                        snowBallValue = currentsSnowBallValue;
                        forPrintingSnowballSnow = snowballSnow;
                        forPrintingSnowballTime = snowballTime;
                        forPrintingSnowballQuality = snowballQuality;

                    }
                }
                
            }
            Console.WriteLine($"{forPrintingSnowballSnow} : {forPrintingSnowballTime} = {snowBallValue} ({forPrintingSnowballQuality})");
        }
    }
}
