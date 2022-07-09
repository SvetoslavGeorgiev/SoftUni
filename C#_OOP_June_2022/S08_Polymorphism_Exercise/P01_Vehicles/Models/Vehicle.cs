using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.Engine;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDrive, IRefill
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKm;

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set 
            { 
                fuelQuantity = value; 
            }
        }

        public double FuelConsumptionPerKm
        {
            get => fuelConsumptionPerKm;
            private set 
            { 
                fuelConsumptionPerKm = value; 
            }
        }

        public abstract string Drive(double distance);

        public abstract void Refill(double fuel);

        protected bool IsDistanceDrivable(double distance)
        {
            if (GetType().Name == "Car")
            {
                var fuel = FuelQuantity - (FuelConsumptionPerKm + Constants.CarAirConditionerFuelIncrement) * distance;
                if (fuel < 0)
                {
                    return false;
                }
                return true;
            }
            else
            {
                var fuel = FuelQuantity - (FuelConsumptionPerKm + Constants.TruckAirConditionerFuelIncrement) * distance;
                if (fuel < 0)
                {
                    return false;
                }
                return true;
            }
            
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {((decimal)fuelQuantity).ToString("F2")}";
        }
    }
}
