using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWiskey = double.Parse(Console.ReadLine());
            double amountOfBeer = double.Parse(Console.ReadLine());
            double amountOfWine = double.Parse(Console.ReadLine());
            double amountOfRakiya = double.Parse(Console.ReadLine());
            double amountOfWeskey = double.Parse(Console.ReadLine());

            double priceRakiya = priceWiskey / 2;
            double priceWine = priceRakiya - priceRakiya * 0.4;
            double priceBeer = priceRakiya - priceRakiya * 0.8;

            double sumForWiskey = priceWiskey * amountOfWeskey;
            double sumForRakiya = priceRakiya * amountOfRakiya;
            double sumForWine = priceWine * amountOfWine;
            double sumForBeer = priceBeer * amountOfBeer;

            double TotalAmount = sumForWiskey + sumForRakiya + sumForWine + sumForBeer;

            Console.WriteLine($"{TotalAmount:F2}");
        }
    }
}
