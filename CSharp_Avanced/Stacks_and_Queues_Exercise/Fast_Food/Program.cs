using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            var quantityOfFood = int.Parse(Console.ReadLine());

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Queue<int> orders = new Queue<int>(input);
            
            var maxOrder = int.MinValue;

            var numberOfAllOrders = orders.Count;
            bool isTrue = false;

            for (int i = 0; i <= numberOfAllOrders - 1; i++)
            {
                var currentOrder = orders.Dequeue();
                if (currentOrder > maxOrder)
                {
                    maxOrder = currentOrder;
                }

                if (isTrue)
                {
                    orders.Enqueue(currentOrder);
                }
                else
                {
                    if (quantityOfFood >= currentOrder)
                    {
                        quantityOfFood -= currentOrder;
                    }
                    else
                    {
                        isTrue = true;
                        orders.Enqueue(currentOrder);
                    }
                }
            }

            if (orders.Count == 0)
            {
                Console.WriteLine(maxOrder);
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine(maxOrder);
                var leftOrders = new StringBuilder();
                while (orders.Count != 0)
                {
                    leftOrders.Append($"{orders.Dequeue()} ");
                }

                Console.Write($"Orders left: {leftOrders}");
            }

        }
    }
}
