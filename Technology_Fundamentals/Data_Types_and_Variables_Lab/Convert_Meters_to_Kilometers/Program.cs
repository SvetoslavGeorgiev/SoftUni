using System;

namespace Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var meters = double.Parse(Console.ReadLine());

            var kilometers = meters / 1000;

            Console.WriteLine($"{kilometers:F2}");




        }
    }
}
