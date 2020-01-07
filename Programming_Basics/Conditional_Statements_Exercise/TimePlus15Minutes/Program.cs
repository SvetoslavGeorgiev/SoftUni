using System;

namespace TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int hoursInMimutes = hours * 60;
            int totalMinutes = hoursInMimutes + minutes + 15;
            int displayHours = totalMinutes / 60;
            int leftOver = totalMinutes % 60;

            if (displayHours >= 24)
            {
                if (leftOver == 1 && leftOver == 01)
                {
                    Console.WriteLine("0:01");
                }
                else if (leftOver == 2 && leftOver == 02)
                {
                    Console.WriteLine("0:02");
                }
                else if (leftOver == 3 && leftOver == 03)
                {
                    Console.WriteLine("0:03");
                }
                else if (leftOver == 4 && leftOver == 04)
                {
                    Console.WriteLine("0:04");
                }
                else if (leftOver == 5 && leftOver == 05)
                {
                    Console.WriteLine("0:05");
                }
                else if (leftOver == 6 && leftOver == 06)
                {
                    Console.WriteLine("0:06");
                }
                else if (leftOver == 7 && leftOver == 07)
                {
                    Console.WriteLine("0:07");
                }
                else if (leftOver == 8 && leftOver == 08)
                {
                    Console.WriteLine("0:08");
                }
                else if (leftOver == 9 && leftOver == 09)
                {
                    Console.WriteLine("0:09");
                }
                else if (leftOver == 0 && leftOver == 00)
                {
                    Console.WriteLine("0:00");
                }
                else
                { 
                    Console.WriteLine("0:" + leftOver);
                }
            }
            else
            {
                if (leftOver == 1 && leftOver == 01)
                {
                    Console.WriteLine(displayHours + ":01");
                }
                else if (leftOver == 2 && leftOver == 02)
                {
                    Console.WriteLine(displayHours + ":02");
                }
                else if (leftOver == 3 && leftOver == 03)
                {
                    Console.WriteLine(displayHours + ":03");
                }
                else if (leftOver == 4 && leftOver == 04)
                {
                    Console.WriteLine(displayHours + ":04");
                }
                else if (leftOver == 5 && leftOver == 05)
                {
                    Console.WriteLine(displayHours + ":05");
                }
                else if (leftOver == 6 && leftOver == 06)
                {
                    Console.WriteLine(displayHours + ":06");
                }
                else if (leftOver == 7 && leftOver == 07)
                {
                    Console.WriteLine(displayHours + ":07");
                }
                else if (leftOver == 8 && leftOver == 08)
                {
                    Console.WriteLine(displayHours + ":08");
                }
                else if (leftOver == 9 && leftOver == 09)
                {
                    Console.WriteLine(displayHours + ":09");
                }
                else if (leftOver == 0 && leftOver == 00)
                {
                    Console.WriteLine(displayHours + ":00");
                }
                else
                {
                    Console.WriteLine(displayHours + ":" + leftOver);
                }
            }
        }
    }
}

