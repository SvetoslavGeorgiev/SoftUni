using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();

            Queue<string> qu = new Queue<string>(numbers);

            

            while (qu.Count !=0)
            {
                var currentNumber = int.Parse(qu.Dequeue());

                if (currentNumber % 2 == 0)
                {
                    if (qu.Count != 0)
                    {
                        Console.Write($"{currentNumber}, ");
                    }
                    else
                    {
                        Console.Write($"{currentNumber}");
                    }
                    
                }
            }
        }
    }
}
