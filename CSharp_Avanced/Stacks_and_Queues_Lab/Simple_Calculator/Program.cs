using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var stack = new Stack<string>(input.Reverse());

            var sum = int.Parse(stack.Pop());

            while (stack.Any())
            {
                
                if (stack.Pop() == "+")
                {
                    sum += int.Parse(stack.Pop());
                }
                else
                {
                    sum -= int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(sum);
        }
    }
}
