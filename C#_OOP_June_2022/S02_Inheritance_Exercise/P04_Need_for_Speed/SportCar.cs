using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePowwer, double fuel) : base(horsePowwer, fuel)
        {
        }



        public override double FuelConsumption
        {
            get => 10.00;
        }
    }
}
