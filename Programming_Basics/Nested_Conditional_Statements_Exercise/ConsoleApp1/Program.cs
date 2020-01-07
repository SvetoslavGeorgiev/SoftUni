using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double examhour = double.Parse(Console.ReadLine());
            double examminutes = double.Parse(Console.ReadLine());
            double arrivalhour = double.Parse(Console.ReadLine());
            double arrivalminutes = double.Parse(Console.ReadLine());

            double examtime = examhour * 60 + examminutes;
            double arrivaltime = arrivalhour * 60 + arrivalminutes;
            double diff = examtime - arrivaltime;
            double hours = 0;
            double minutes = 0;

            if (diff <= -1)
                Console.WriteLine("Late");
            else if (diff >= 0 && diff <= 30)
                Console.WriteLine("On Time");
            else if (diff > 30)
                Console.WriteLine("Early");


            if (diff > 0 && diff < 60)
                Console.WriteLine($"{diff} minutes before the start");

            else if (diff >= 60)
            {

                hours = Math.Truncate(diff / 60);
                minutes = Math.Abs(diff % 60);
                if (minutes < 10)
                    Console.WriteLine($"{hours}:0{minutes} hours before the start");
                else
                    Console.WriteLine($"{hours}:{minutes} hours before the start");
            }

            else if (diff < 0 && diff >= -59)
                Console.WriteLine($"{Math.Abs(diff)} minutes after the start");

            else if (diff <= -60)
            {

                hours = Math.Abs(Math.Truncate(diff / 60));
                minutes = Math.Abs(diff % 60);
                if (minutes < 10)
                    Console.WriteLine($"{hours}:0{minutes} hours after the start");
                else
                    Console.WriteLine($"{hours}:{minutes} hours after the start");
            }
        }
    }
}
