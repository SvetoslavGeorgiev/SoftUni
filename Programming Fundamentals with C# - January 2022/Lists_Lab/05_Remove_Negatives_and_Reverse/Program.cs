using System;
using System.Linq;

namespace _05_Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(x => x > 0)
                .Reverse()
                .ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                list.ForEach(x => Console.Write($"{x} "));
            }
        }
    }
}
