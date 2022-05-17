using System;
using System.Linq;
using System.Collections.Generic;

namespace P03_Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfActions = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();


            for (int i = 0; i < numberOfActions; i++)
            {
                var action = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (action[0] == 1)
                {
                    stack.Push(action[1]);
                }
                else if (action[0] == 2)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }
                else if (action[0] == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));

        }
    }
}