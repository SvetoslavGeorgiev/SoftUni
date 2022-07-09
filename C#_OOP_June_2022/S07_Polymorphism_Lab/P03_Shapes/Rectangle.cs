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
            this.height = height;
            this.width = width;
        }

        //public double Height
        //{
        //    get => height;
        //    private set 
        //    { 
        //        height = value;
        //    }
        //}
        //public double Width
        //{
        //    get => width;
        //    private set 
        //    {
        //        width = value; 
        //    }
        //}
        public override double CalculateArea()
        {
            return width * height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (width + height);
        }

        public sealed override string Draw()
        {
            StringBuilder sb = new StringBuilder();
            DrawLine(width, '*', '*', sb);
            for (int i = 0; i < height - 1; i++)
            {
                DrawLine(width, '*', ' ', sb);
            }
            DrawLine(width, '*', '*', sb);

            return sb.ToString();
        }

        private void DrawLine(double width, char end, char mid, StringBuilder sb)
        {
            sb.Append(end);
            for (int i = 0; i < width - 1; i++)
            {
                sb.Append(mid);
            }
            sb.AppendLine(end.ToString());
        }
    }
}
