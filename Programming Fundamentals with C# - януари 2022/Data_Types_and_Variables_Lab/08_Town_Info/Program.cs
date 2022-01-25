using System;

namespace _08_Town_Info
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var townName = Console.ReadLine();
            var population = int.Parse(Console.ReadLine());
            var area = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {townName} has population of {population} and area {area} square km.");
        }
    }
}
