using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var queries = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 1; i <= queries; i++)
            {
                var command = Console.ReadLine().Split().Select(int.Parse).ToList();

                if (command[0] == 1)
                {
                    numbers.Push(command[1]);
                }
                else if (command[0] == 2)
                {
                    if (numbers.Count != 0)
                    {
                        numbers.Pop();
                    }
                }
                else
                {
                    
                    if (numbers.Count > 0)
                    {
                        //int maxOrMinNumber = MinMaxNumber(command[0], numbers);
                        int maxOrMinNumber = MaxOrMin.MinMaxNumber(command[0], numbers);
                        Console.WriteLine(maxOrMinNumber);
                    }
                }
            }
            while (numbers.Count != 0)
            {
                if (numbers.Count != 1)
                {
                    Console.Write($"{numbers.Pop()}, ");
                }
                else
                {
                    Console.Write($"{numbers.Pop()}");
                }
                
            }
        }

        //public static int MinMaxNumber(int number, Stack<int> numbers)
        //{
        //    var numbers1 = numbers.ToArray();
        //    var maxOrMinNumber = 0;
        //    if (number == 3)
        //    {
        //        var tempNumber = int.MinValue;
        //        while (numbers.Count != 0)
        //        {

        //            var currentNumber = numbers.Pop();

        //            if (currentNumber > tempNumber)
        //            {
        //                tempNumber = currentNumber;
        //            }
        //        }
        //        maxOrMinNumber = tempNumber;
        //    }
        //    else
        //    {
        //        var tempNumber = int.MaxValue;
        //        while (numbers.Count != 0)
        //        {

        //            var currentNumber = numbers.Pop();

        //            if (currentNumber < tempNumber)
        //            {
        //                tempNumber = currentNumber;
        //            }
        //        }
        //        maxOrMinNumber = tempNumber;
        //    }

        //    foreach (var item in numbers1.Reverse())
        //    {
        //        numbers.Push(item);
        //    }

        //    return maxOrMinNumber;
        //}
    }
}
