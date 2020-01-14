using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;

            var sum = 0.0;

            var totalIncome = 0.0;
            var names = new List<string>();
            var products = new List<string>();
            var totalPrice = new List<double>();

            while ((command = Console.ReadLine()) != "end of shift")
            {
                //(?:%)(?<name>[A-z][a-z]{1,})(?:%<)(?<product>\w+)(?:>\|)(?<quantity>\d+)(?:\|)(?<price>\d+.\d+)
                var matches = Regex.Matches(command, @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+)\$");

                foreach (Match item in matches)
                {
                    string name = item.Groups["name"].ToString();
                    string product = item.Groups["product"].ToString();
                    var price = double.Parse(item.Groups["price"].ToString());
                    var quantity = int.Parse(item.Groups["quantity"].ToString());
                    sum = price * quantity;
                    totalIncome += sum;

                    names.Add(name);
                    products.Add(product);
                    totalPrice.Add(sum);
                    sum = 0.0;
                }
            }

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"{names[i]}: {products[i]} - {totalPrice[i]:F2}");
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
