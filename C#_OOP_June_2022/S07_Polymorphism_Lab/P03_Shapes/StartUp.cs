namespace Shapes
{
    using System;
    public class StartUp
    {
        static void Main()
        {

            var heght = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var radius = double.Parse(Console.ReadLine());

            Shape shape;

            shape = new Rectangle(heght, width);

            

            if (shape is Rectangle)
            {
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine(shape.CalculatePerimeter());
                Console.WriteLine(shape.Draw());
            }


            shape = new Circle(radius);


            if (shape is Circle)
            {
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine(shape.CalculatePerimeter());
                Console.WriteLine(shape.Draw());
            }
            

        }
    }
}
