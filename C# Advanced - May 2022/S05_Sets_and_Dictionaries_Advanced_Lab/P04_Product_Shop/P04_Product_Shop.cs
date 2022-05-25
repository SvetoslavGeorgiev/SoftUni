using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Product_Shop
{
    class P04_Product_Shop
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Revision")
            {

                var token = command.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var shop = token[0];
                var product = token[1];
                var price = double.Parse(token[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());

                }
                shops[shop].Add(product, price);

            }

            var orderedShops = shops.OrderBy(s => s.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var shop in orderedShops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var kvp in shop.Value)
                {
                    Console.WriteLine($"Product: {kvp.Key}, Price: {kvp.Value}");
                }
            }
        }
    }
}
