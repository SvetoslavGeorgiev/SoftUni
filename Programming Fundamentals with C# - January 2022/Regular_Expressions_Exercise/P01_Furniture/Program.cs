using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P01_Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;

            var furnitures = new List<string>();

            double sum = 0;

            while ((command = Console.ReadLine()) != "Purchase")
            {
                var match = Regex.Matches(command, @"(?:[>]{2})(?<name>[?:A-Za-z]*)(?:([<]{2}))(?<price>\d+[.]?\d+)(?:[!])(?<quantity>\d*)");

                foreach (Match item in match)
                {
                    string name = item.Groups["name"].ToString();
                    furnitures.Add(name);
                    var price = double.Parse(item.Groups["price"].ToString());
                    var quantity = int.Parse(item.Groups["quantity"].ToString());
                    sum += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (var item in furnitures)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}