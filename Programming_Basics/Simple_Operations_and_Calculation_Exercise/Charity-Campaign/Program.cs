using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int backers = int.Parse(Console.ReadLine());
            int cake = int.Parse(Console.ReadLine());
            int gufrety = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double priceCake = 45;
            double priceGufrety = 5.80;
            double pricePancakes = 3.20;

            double amountForCakes = cake * priceCake;
            double amountForGufrety = gufrety * priceGufrety;
            double amounForPancakes = pancakes * pricePancakes;

            double allGoodsForDay = (amountForCakes + amountForGufrety + amounForPancakes) * backers;
            double totalAmountForCampaing = allGoodsForDay * days;

            double amountForexpencess = totalAmountForCampaing / 8;

            double colectAmountForCampaing = totalAmountForCampaing - amountForexpencess;

            Console.WriteLine($"{colectAmountForCampaing:F2}");
        }
    }
}
