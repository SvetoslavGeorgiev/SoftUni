using System;

namespace Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            var population = int.Parse(Console.ReadLine());
            var squareKm = int.Parse(Console.ReadLine());


            Console.WriteLine($"Town {city} has population of {population} and area {squareKm} square km.");
        }
    }
}
