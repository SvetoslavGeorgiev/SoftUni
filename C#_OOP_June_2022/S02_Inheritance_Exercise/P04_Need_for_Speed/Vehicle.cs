using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {

        public Vehicle(int horsePowwer, double fuel)
        {
            
            HorsePowwer = horsePowwer;
            Fuel = fuel;
        }

        public double DefaultFuelConsumption { get; set; } = 1.25;
        public virtual double FuelConsumption 
        {
            get => DefaultFuelConsumption;
        }
        public double Fuel { get; set; }
        public int HorsePowwer { get; set; }
        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }

        public override string ToString()
        {
            return $"HorsePower: {HorsePowwer} Fuel: {Fuel}";
        }
    }
}
