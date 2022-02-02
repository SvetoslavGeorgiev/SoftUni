using System;
using System.Linq;

namespace _08_Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            var sum = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int k = i + 1; k < arr.Length; k++)
                {
                    if (sum == (arr[i] + arr[k]))
                    {
                        Console.WriteLine($"{arr[i]} {arr[k]}");
                    }

                }
            }
        }
    }
}