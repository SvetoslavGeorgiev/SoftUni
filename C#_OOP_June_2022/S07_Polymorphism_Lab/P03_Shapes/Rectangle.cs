namespace Shapes
{
    using System;
    using System.Text;

    public class Rectangle : Shape
    {
        private double height;
        private double width;

        
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get => height;
            private set
            {
                height = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                width = value;
            }
        }
        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public sealed override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
