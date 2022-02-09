using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var products = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var product = Console.ReadLine();
                products.Add(product);
            }

            products.Sort();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}