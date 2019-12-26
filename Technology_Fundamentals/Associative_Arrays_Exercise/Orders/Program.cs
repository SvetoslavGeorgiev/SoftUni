using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var quantityOfTheProduct = new Dictionary<string, int>();
            var orders = new Dictionary<string, double>();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "buy")
            {
                var list = command.Split().ToList();

                var product = list[0];
                var quantity = int.Parse(list[2]);
                var price = double.Parse(list[1]);

                if (orders.ContainsKey(product))
                {
                    if (orders[product] != price)
                    {
                        orders[product] = price;
                    }
                }
                else
                {
                    orders.Add(product, price);
                }
                if (quantityOfTheProduct.ContainsKey(product))
                {
                    quantityOfTheProduct[product] += quantity;
                }
                else
                {
                    quantityOfTheProduct.Add(product, quantity);
                }
            }
            foreach (var quantity in quantityOfTheProduct)
            {
                if (orders.ContainsKey(quantity.Key))
                {
                    orders[quantity.Key] *= quantity.Value;
                }
            }

            foreach (var products in orders)
            {
                Console.WriteLine($"{products.Key} -> {products.Value:F2}");
            }
        }
    }

    //class Order
    //{
    //    public Order()
    //    {

    //    }
    //    public string Product { get; set; }
    //    public int Quantity { get; set; }
    //    public double Price { get; set; }
    //}
}
