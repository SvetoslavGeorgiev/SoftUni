using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            var wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                var currentBottle = bottles.Pop();
                var currentCup = cups.Peek();

                var difference = currentCup - currentBottle;

                while (difference > 0 && bottles.Any())
                {
                    currentBottle = bottles.Pop();
                    difference -= currentBottle;
                }
                if (difference <= 0)
                {
                    cups.Dequeue();
                    wastedWater += (difference * -1);
                }
            }
            if (cups.Any())
            {

                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
