using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;

            Queue<string> queueSupermaket = new Queue<string>();

            while ((command = Console.ReadLine()) != "End")
            {
                
                if (command != "Paid")
                {
                    queueSupermaket.Enqueue(command);
                }
                else
                {
                    while (queueSupermaket.Count != 0)
                    {
                        Console.WriteLine(queueSupermaket.Dequeue());
                    }
                }
            }
            Console.WriteLine($"{queueSupermaket.Count} people remaining.");
        }
    }
}
