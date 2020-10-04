using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();


            Func<int, int, int> sortFunc = (a, b) => a.CompareTo(b);
            Action<int[], int[]> print = (x, y) => Console.WriteLine($"{string.Join(" ", x)} {string.Join(" ", y)}");

            var evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();
            var oddNumbers = numbers.Where(x => x % 2 != 0).ToArray();

            Array.Sort(evenNumbers, new Comparison<int>(sortFunc));
            Array.Sort(oddNumbers, new Comparison<int>(sortFunc));

            print(evenNumbers, oddNumbers);

            // Second solution

            //Func<int, int, int> sortFunc = (a, b) => (a % 2 == 0 && b % 2 != 0) ? -1 : (a % 2 != 0 && b % 2 == 0) ? 1 : a.CompareTo(b);

            //Array.Sort(numbers, new Comparison<int>(sortFunc));

            //Console.WriteLine(string.Join(" ", numbers));


            // Third sopution
            
            //var evenNumbers = new List<int>();

            //var oddNumbers = new List<int>();

            //foreach (var number in numbers)
            //{
            //    if (number % 2 == 0)
            //    {
            //        evenNumbers.Add(number);
            //    }
            //    else
            //    {
            //        oddNumbers.Add(number);
            //    }
            //}
            //var allNumbers = new List<int>();
            //evenNumbers.Sort();
            //evenNumbers.ForEach(x => allNumbers.Add(x));
            //oddNumbers.Sort();
            //oddNumbers.ForEach(x => allNumbers.Add(x));

            //Console.WriteLine(string.Join(" ", allNumbers));
        }
    }
}
