using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPumpa = int.Parse(Console.ReadLine());

            Queue<int> circle = new Queue<int>();

            var difference = 0;

            for (int i = 0; i < numberOfPumpa; i++)
            {
                var pump = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                difference = pump[0] - pump[1];

                circle.Enqueue(difference);
            }

            var petrol = 0;
            var index = int.MaxValue;
            var currentPump = 0;

            for (int i = 1; i <= numberOfPumpa; i++)
            {
                var newCircle = new Queue<int>(circle);
                for (int k = 1; k < i; k++)
                {
                    newCircle.Enqueue(newCircle.Dequeue());
                }

                for (int j = 0; j < newCircle.Count; j++)
                {
                    currentPump += newCircle.Dequeue();
                    petrol = currentPump;
                    if (petrol < 0)
                    {
                        index = int.MaxValue;
                        break;
                    }
                    else if (petrol >= 0)
                    {
                        if (index >= i)
                        {
                            index = i - 1;
                        }
                    }
                    if (newCircle.Count == 0)
                    {
                        Console.WriteLine(index);
                        return;
                    }
                    j = -1;
                }

                currentPump = 0;
            }

        }
    }
}
