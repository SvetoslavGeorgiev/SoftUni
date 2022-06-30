using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePowwer, double fuel) : base(horsePowwer, fuel)
        {



        }

        

        public override double FuelConsumption 
        { 
            get => 8.00; 
        }
    }
}
