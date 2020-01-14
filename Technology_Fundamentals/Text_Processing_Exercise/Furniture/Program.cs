using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            //Just because doesn't need a Dictionary,it's give me a runTime error and that why i have _v2!! 
            var command = string.Empty;

            var matches = new Dictionary<string, Dictionary<double, int>>();

            double sum = 0;

            while ((command = Console.ReadLine()) != "Purchase")
            {
                var match = Regex.Matches(command, @"(?:[>]{2})(?<name>[?:A-Za-z]*)(?:([<]{2}))(?<price>\d+[.]?\d+)(?:[!])(?<quantity>\d*)");


                foreach (Match item in match)
                {
                    string name = item.Groups["name"].ToString();
                    matches.Add(name, new Dictionary<double, int>());
                    var price = double.Parse(item.Groups["price"].ToString());
                    var quantity = int.Parse(item.Groups["quantity"].ToString());
                    sum += price * quantity;
                    matches[name].Add(price, quantity);
                }
                //var list = match.Cast<Match>().SelectMany(x => x.Groups.Cast<Capture>().Skip(1).Select(c => c.Value));


                //foreach (var item in list)
                //{
                //    Console.WriteLine(item);
                //}
            }
            Console.WriteLine("Bought furniture:");
            foreach (var item in matches)
            {
                Console.WriteLine($"{item.Key}");
            }
            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
