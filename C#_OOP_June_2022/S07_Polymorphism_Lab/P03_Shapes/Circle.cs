namespace Shapes
{
    using System;
    using System.Text;

    public class Circle : Shape
    {
        private double radius;

        
        public Circle(double radius)
        {
            this.radius = radius;
        }

        //public double Radius
        //{
        //    get => radius;
        //    private set 
        //    { 
        //        radius = value; 
        //    }
        //}


        public override double CalculateArea()
        {
            return (Math.PI * Math.Pow(radius, 2));
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public sealed override string Draw()
        {
            var sb = new StringBuilder();
            var rIn = radius - 0.4;
            var rOut = radius + 0.4;

            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < rOut; x += 0.5)
                {
                    var value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        sb.Append("*");
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
