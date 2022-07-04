using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            var radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            IDrawable rect = new Rectangle(width, height);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(rect.Draw());
        }
    }
}
