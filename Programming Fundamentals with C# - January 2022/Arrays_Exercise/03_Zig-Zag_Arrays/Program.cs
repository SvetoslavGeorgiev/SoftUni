using System;
using System.Linq;

namespace _03_Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = int.Parse(Console.ReadLine());

            var oddArr = new int[inputs];
            var evenArr = new int[inputs];

            for (int i = 0; i < inputs; i++)
            {
                var currentArr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                if (i % 2 == 0)
                {
                    oddArr[i] = currentArr[0];
                    evenArr[i] = currentArr[1];
                }
                else
                {
                    oddArr[i] = currentArr[1];
                    evenArr[i] = currentArr[0];
                }
                
            }
            Console.WriteLine(string.Join(" ", oddArr));
            Console.WriteLine(string.Join(" ", evenArr));
        }
    }
}