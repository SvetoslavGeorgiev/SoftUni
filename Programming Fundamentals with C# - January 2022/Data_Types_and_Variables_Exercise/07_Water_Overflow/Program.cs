using System;

namespace _07_Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var linesOfinput = int.Parse(Console.ReadLine());
            var totalLitersOfWater = 0;
            for (int i = 0; i < linesOfinput; i++)
            {
                var litersOfWater = int.Parse(Console.ReadLine());

                totalLitersOfWater += litersOfWater;
                if (totalLitersOfWater > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    totalLitersOfWater -= litersOfWater;
                }
            }
            Console.WriteLine(totalLitersOfWater);
        }
    }
}
