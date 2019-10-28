using System;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double squareSide = double.Parse(Console.ReadLine());
                double squareArea = squareSide * squareSide;
                Console.WriteLine($"{squareArea:F3}");
            }
            else if (figure == "rectangle")
            {
                double rectanglesideA = double.Parse(Console.ReadLine());
                double rectanglesideB = double.Parse(Console.ReadLine());

                double rectangleArea = rectanglesideA * rectanglesideB;

                Console.WriteLine($"{rectangleArea:F3}");
            }
            else if (figure == "circle")
            {
                double circleRadius = double.Parse(Console.ReadLine());
                double circleArea = Math.PI * circleRadius * circleRadius;
                Console.WriteLine($"{circleArea:F3}");
            }
            else if (figure == "triangle")
            {
                double triangleSide = double.Parse(Console.ReadLine());
                double triangleHight = double.Parse(Console.ReadLine());

                double trangleArea = triangleSide * triangleHight / 2;
                Console.WriteLine($"{trangleArea:F3}");
            }
        }
    }
}
