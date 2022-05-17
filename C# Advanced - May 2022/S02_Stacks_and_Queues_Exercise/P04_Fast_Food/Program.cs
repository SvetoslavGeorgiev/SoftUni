using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var foodQuantity = int.Parse(Console.ReadLine());

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Queue<int> orders = new Queue<int>(input);

            Console.WriteLine(orders.Max());

            while (orders.Any())
            {

                var currentOrder = orders.Peek();

                if (currentOrder <= foodQuantity)
                {
                    orders.Dequeue();
                    foodQuantity -= currentOrder;
                }
                else
                {
                    break;
                }
            }

            if (orders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
