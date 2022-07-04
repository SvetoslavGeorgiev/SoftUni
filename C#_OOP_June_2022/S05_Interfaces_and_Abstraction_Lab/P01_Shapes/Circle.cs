namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Circle : IDrawable
    {
        private int radius;
        public Circle(int radius)
        {
            Radius = radius;
        }

        public int Radius 
        { 
            get => radius;
            private set 
            { 
                radius = value; 
            }

        }
        public string Draw()
        {
            var sb = new StringBuilder();
            var rIn = Radius - 0.4;
            var rOut = Radius + 0.4;

            for (double y = Radius; y >= -Radius; --y)
            {
                for (double x = -Radius; x < rOut; x += 0.5)
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
