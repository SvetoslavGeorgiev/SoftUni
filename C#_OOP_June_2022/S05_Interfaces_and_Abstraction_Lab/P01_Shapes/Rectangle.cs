namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width 
        { 
            get => width;
            private set
            {
                width = value;
            } 
        }
        public int Height 
        { 
            get => height;
            private set
            {
                height = value;
            } 
        }

        public string Draw()
        {
            StringBuilder sb = new StringBuilder();

            DrawLine(Width, '*', '*', sb);
            for (int i = 0; i < Height - 1; i++)
            {
                DrawLine(Width, '*', ' ', sb);
            }
            DrawLine(Width, '*', '*', sb);

            return sb.ToString();
        }

        private void DrawLine(int width, char end, char mid, StringBuilder sb)
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
