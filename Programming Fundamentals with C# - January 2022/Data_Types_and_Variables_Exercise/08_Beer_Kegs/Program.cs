using System;

namespace _08_Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = int.Parse(Console.ReadLine());

            var biggestKeg = string.Empty;
            var biggestVolume = 0.00;
            for (int i = 0; i < inputs; i++)
            {
                var model = Console.ReadLine();
                var radius = double.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());
                
                var pi = Math.PI;
                var volume = pi * (radius * radius) * height;
                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    biggestKeg = model;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
