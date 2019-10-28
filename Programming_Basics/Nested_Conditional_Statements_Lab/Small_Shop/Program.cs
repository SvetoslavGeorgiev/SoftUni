using System;

namespace Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfTheProduct = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if (city == "Sofia")
            {
                if (nameOfTheProduct == "coffee")
                {
                    Console.WriteLine(quantity * 0.50);
                }
                else if (nameOfTheProduct == "water")
                {
                    Console.WriteLine(quantity * 0.80);
                }
                else if (nameOfTheProduct == "beer")
                {
                    Console.WriteLine(quantity * 1.20);
                }
                else if (nameOfTheProduct == "sweets")
                {
                    Console.WriteLine(quantity * 1.45);
                }
                else if (nameOfTheProduct == "peanuts")
                {
                    Console.WriteLine(quantity * 1.60);
                }
            }
            else if (city == "Plovdiv")
            {
                if (nameOfTheProduct == "coffee")
                {
                    Console.WriteLine(quantity * 0.40);
                }
                else if (nameOfTheProduct == "water")
                {
                    Console.WriteLine(quantity * 0.70);
                }
                else if (nameOfTheProduct == "beer")
                {
                    Console.WriteLine(quantity * 1.15);
                }
                else if (nameOfTheProduct == "sweets")
                {
                    Console.WriteLine(quantity * 1.30);
                }
                else if (nameOfTheProduct == "peanuts")
                {
                    Console.WriteLine(quantity * 1.50);
                }
            }
            else if (city == "Varna")
            {
                if (nameOfTheProduct == "coffee")
                {
                    Console.WriteLine(quantity * 0.45);
                }
                else if (nameOfTheProduct == "water")
                {
                    Console.WriteLine(quantity * 0.70);
                }
                else if (nameOfTheProduct == "beer")
                {
                    Console.WriteLine(quantity * 1.10);
                }
                else if (nameOfTheProduct == "sweets")
                {
                    Console.WriteLine(quantity * 1.35);
                }
                else if (nameOfTheProduct == "peanuts")
                {
                    Console.WriteLine(quantity * 1.55);
                }
            }
        }
    }
}
