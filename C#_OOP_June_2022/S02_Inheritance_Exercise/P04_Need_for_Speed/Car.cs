using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePowwer, double fuel) : base(horsePowwer, fuel)
        {
        }


        

        public override double FuelConsumption
        {
            get => 3.00;
        }
    }
}
