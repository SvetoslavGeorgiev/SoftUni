using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
            private set
            {
                //if (value <= 0)
                //{
                //    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                //}
                ValidateForPozitiveNumber(value, "Length");
                length = value;
            }
        }


        public double Width
        {
            get { return width; }
            private set
            {
                //if (value <= 0)
                //{
                //    throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
                //}
                ValidateForPozitiveNumber(value, "Width");
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            private set
            {
                //if (value <= 0)
                //{
                //    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
                //}
                ValidateForPozitiveNumber(value, "Height");
                height = value;
            }
        }

        //area formulas:
        //Volume = lwh
        //Lateral Surface Area = 2lh + 2wh
        //Surface Area = 2lw + 2lh + 2wh

        public double SurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double Volume()
        {
            return Length * Width * Height;
        }

        private void ValidateForPozitiveNumber(double number, string property)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"{property} cannot be zero or negative.");
            }
        }

    }
}
