using System;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOfSteps = double.Parse(Console.ReadLine());
            double numberOfDancers = double.Parse(Console.ReadLine());
            double numberOfDays = double.Parse(Console.ReadLine());

            double stepsLernForDay = ((numberOfSteps / numberOfDays) / numberOfSteps) * 100;
            double stepsLernForDayRound = Math.Ceiling(stepsLernForDay);
            double percentForDancer = stepsLernForDayRound / numberOfDancers;
            double thirteenPercents = 13;

            if (stepsLernForDayRound <= thirteenPercents)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {percentForDancer:F2}%.");
            }
            else if (stepsLernForDayRound > thirteenPercents)
            {
                Console.WriteLine($"No, They will not succeed in that goal! Required {percentForDancer:F2}% steps to be learned per day.");
            }
        }
    }
}
