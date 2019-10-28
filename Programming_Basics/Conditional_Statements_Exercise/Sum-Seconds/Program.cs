using System;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstAtlet = int.Parse(Console.ReadLine());
            int secondAtlet = int.Parse(Console.ReadLine());
            int thirdAtlet = int.Parse(Console.ReadLine());

            int timeOfAll = firstAtlet + secondAtlet + thirdAtlet;
            int timeInMinutes = timeOfAll / 60;
            int leftOver = timeOfAll % 60;
            
            if (leftOver == 1)
            {
                Console.WriteLine(timeInMinutes + ":01");
            }
            else if (leftOver == 2)
            {
                Console.WriteLine(timeInMinutes + ":02");
            }
            else if (leftOver == 3)
            {
                Console.WriteLine(timeInMinutes + ":03");
            }
            else if (leftOver == 4)
            {
                Console.WriteLine(timeInMinutes + ":04");
            }
            else if (leftOver == 5)
            {
                Console.WriteLine(timeInMinutes + ":05");
            }
            else if (leftOver == 6)
            {
                Console.WriteLine(timeInMinutes + ":06");
            }
            else if (leftOver == 7)
            {
                Console.WriteLine(timeInMinutes + ":07");
            }
            else if (leftOver == 8)
            {
                Console.WriteLine(timeInMinutes + ":08");
            }
            else if (leftOver == 9)
            {
                Console.WriteLine(timeInMinutes + ":09");
            }
            else if (leftOver == 0)
            {
                Console.WriteLine(timeInMinutes + ":00");
            }
            else
            {
                Console.WriteLine(timeInMinutes + ":" + leftOver);
            }
        }
    }
}
