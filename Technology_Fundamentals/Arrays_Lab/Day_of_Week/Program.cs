using System;

namespace Day_of_Week
{
    class Program
    {
        static void Main()
        {
            string[] daysOfTheWeek = new string[8];


            daysOfTheWeek[1] = "Monday";
            daysOfTheWeek[2] = "Tuesday";
            daysOfTheWeek[3] = "Wednesday";
            daysOfTheWeek[4] = "Thursday";
            daysOfTheWeek[5] = "Friday";
            daysOfTheWeek[6] = "Saturday";
            daysOfTheWeek[7] = "Sunday";


            int numer = int.Parse(Console.ReadLine());

            if (numer >=1 && numer <=7)
            {
                Console.WriteLine(daysOfTheWeek[numer]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
