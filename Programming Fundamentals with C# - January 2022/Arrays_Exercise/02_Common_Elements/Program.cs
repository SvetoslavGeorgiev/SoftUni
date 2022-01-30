using System;
using System.Linq;

namespace _02_Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine()
                .Split()
                .ToArray();
            var arr2 = Console.ReadLine()
                .Split()
                .ToArray();

            foreach (var item in arr2)
            {
                if (arr1.Contains(item))
                {
                    Console.Write($"{item} ");
                }
            }
        }
    }
}
