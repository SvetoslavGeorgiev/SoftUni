using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Gauss_Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            
            var originalLenght = list.Count;
            for (int i = 0; i < originalLenght / 2; i++)
            {
                list[i] += list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
