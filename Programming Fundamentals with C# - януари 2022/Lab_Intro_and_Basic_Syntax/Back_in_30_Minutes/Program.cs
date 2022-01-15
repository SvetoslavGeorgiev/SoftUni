using System;

namespace Back_in_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var theNumberForTheHours = int.Parse(Console.ReadLine());
            var theNumberForTheMinutes = int.Parse(Console.ReadLine());


            var newNumberForTheMinutes = theNumberForTheMinutes + 30;
            var newNumberForTheHours = 0;

            if (newNumberForTheMinutes >= 60)
            {
                newNumberForTheMinutes = newNumberForTheMinutes - 60;
                newNumberForTheHours = theNumberForTheHours + 1;
            }
            else
            {
                newNumberForTheHours = theNumberForTheHours;
            }
            if (newNumberForTheHours >= 24)
            {
                newNumberForTheHours = newNumberForTheHours - 24;
            }
            if (newNumberForTheMinutes <= 9)
            {
                Console.WriteLine($"{newNumberForTheHours}:0{newNumberForTheMinutes}");
            }
            else
            {

                Console.WriteLine($"{newNumberForTheHours}:{newNumberForTheMinutes}");
            }
        }
    }
}

