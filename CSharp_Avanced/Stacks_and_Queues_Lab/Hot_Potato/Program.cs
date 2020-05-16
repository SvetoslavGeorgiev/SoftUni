using System;
using System.Collections.Generic;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var allChildren = Console.ReadLine().Split();

            Queue<string> children = new Queue<string>(allChildren);

            var number = int.Parse(Console.ReadLine());
            int counter = 0;

            while (children.Count > 1)
            {
                while (number != counter)
                {
                    if (counter == number - 1)
                    {
                        Console.WriteLine($"Removed {children.Dequeue()}"); 
                    }
                    else
                    {
                        var currentChild = children.Dequeue();
                        children.Enqueue(currentChild);
                    }
                    counter++;
                }
                counter = 0;
            }
            Console.WriteLine($"Last is {children.Peek()}");
        }
    }
}
