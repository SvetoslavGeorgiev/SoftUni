using System;

namespace _06_Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstSide = int.Parse(Console.ReadLine());
            var secondSide = int.Parse(Console.ReadLine());

            int area = CalculateRectangleArea(firstSide, secondSide);
            Console.WriteLine(area);
        }

        static int CalculateRectangleArea(int firstSide, int secondSide)
        {
            var area = 0;
            area = firstSide * secondSide;
            return area;
        }
    }
}
