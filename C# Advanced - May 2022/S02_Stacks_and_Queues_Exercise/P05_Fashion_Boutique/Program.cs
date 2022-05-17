using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList());

            var rackCapacity = int.Parse(Console.ReadLine());


            var rackCount = 0;
            while (stack.Any())
            {
                var currentSum = 0;

                var currentquantity = stack.Peek();

                while (currentSum + currentquantity <= rackCapacity)
                {
                    
                    if (currentSum + currentquantity <= rackCapacity)
                    {
                        currentSum += stack.Pop();
                    }
                    if (stack.Any())
                    {
                        currentquantity = stack.Peek();
                    }
                    else
                    {
                        break;
                    }
                }
                rackCount++;
                
            }

            Console.WriteLine(rackCount);
        }
    }
}
