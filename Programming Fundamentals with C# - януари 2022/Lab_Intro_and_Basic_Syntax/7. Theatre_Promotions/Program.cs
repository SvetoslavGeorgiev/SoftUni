using System;

namespace _7._Theatre_Promotions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var typeOfDaY = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            bool error = false;
            var priceOfTheTiket = 0;
            if (typeOfDaY == "Weekday")
            {
                if (age >= 0 && age <= 18 || age > 64 && age <= 122)
                {
                    priceOfTheTiket = 12;
                }
                else if (age > 18 && age <= 64)
                {
                    priceOfTheTiket = 18;
                }
                else
                {
                    error = true;
                    Console.WriteLine("Error!");
                }
            }
            if (typeOfDaY == "Weekend")
            {
                if (age >= 0 && age <= 18 || age > 64 && age <= 122)
                {
                    priceOfTheTiket = 15;
                }
                else if (age > 18 && age <= 64)
                {
                    priceOfTheTiket = 20;
                }
                else
                {
                    error = true;
                    Console.WriteLine("Error!");
                }
            }
            if (typeOfDaY == "Holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    priceOfTheTiket = 5;
                }
                else if (age > 18 && age <= 64)
                {
                    priceOfTheTiket = 12;
                }
                else if (age > 64 && age <= 122)
                {
                    priceOfTheTiket = 10;
                }
                else
                {
                    error = true;
                    Console.WriteLine("Error!");
                }
            }
            if (!error)
            {
                Console.WriteLine($"{priceOfTheTiket}$");
            }
        }
    }
}
