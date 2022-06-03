using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        private int year;
        private double pressure;

        public int Year { get; set; }
        public double Pressure { get; set; }

    }
}
