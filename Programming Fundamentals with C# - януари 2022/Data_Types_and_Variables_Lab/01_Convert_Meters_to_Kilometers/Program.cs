using System;

namespace _01_Convert_Meters_to_Kilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var meters = decimal.Parse(Console.ReadLine());

            var kilometers = meters / 1000;

            Console.WriteLine($"{kilometers:F2}");
        }
    }
}