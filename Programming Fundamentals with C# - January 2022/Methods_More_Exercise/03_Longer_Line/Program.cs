using System;

namespace _03_Longer_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            var x3 = double.Parse(Console.ReadLine());
            var y3 = double.Parse(Console.ReadLine());
            var x4 = double.Parse(Console.ReadLine());
            var y4 = double.Parse(Console.ReadLine());

            PrintLongerLineBetweenTwoPointInCoordinates(x1, x2, x3, x4, y1, y2, y3, y4);



        }

        private static void PrintLongerLineBetweenTwoPointInCoordinates(double x1, double x2, double x3, double x4, double y1, double y2, double y3, double y4)
        {
            var laneOne = Math.Abs(Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2)));
            var laneTwo = Math.Abs(Math.Sqrt(Math.Pow((x4 - x3), 2) + Math.Pow((y4 - y4), 2)));

            if (laneOne >= laneTwo)
            {
                var closestPoint = GetClosestPointToCenter(x1, y1, x2, y2);
                if (closestPoint == x1)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
                
            }
            else
            {
                var closestPoint = GetClosestPointToCenter(x3, y3, x4, y4);
                if (closestPoint == x3)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
        }
        private static double GetClosestPointToCenter(double x1, double y1, double x2, double y2)
        {
            double c1 = Math.Sqrt((x1 * x1) + (y1 * y1));
            double c2 = Math.Sqrt((x2 * x2) + (y2 * y2));
            

            if (c1 <= c2)
            {
                return x1;
            }
            else
            {
                return x2;
            }
        }
    }
}
