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
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double TankCapacity
        {
            get => tankCapacity;
            private set
            {
                tankCapacity = value;
            }
        }


        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value > TankCapacity)
                {
                    FuelQuantity = 0.00;
                }
                else
                {
                    fuelQuantity = value;
                }
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

        public virtual string DriveEmpry(double distance)
        {
            return string.Empty;
        }

        public abstract void Refill(double fuel);

        protected bool IsDistanceDrivable(double distance)
        {
            if (GetType().Name == Constants.Car)
            {
                var fuel = FuelQuantity - (FuelConsumptionPerKm + Constants.CarAirConditionerFuelIncrement) * distance;
                if (fuel < 0)
                {
                    return false;
                }
                return true;
            }
            else if (GetType().Name == Constants.Truck)
            {
                var fuel = FuelQuantity - (FuelConsumptionPerKm + Constants.TruckAirConditionerFuelIncrement) * distance;
                if (fuel < 0)
                {
                    return false;
                }
                return true;
            }
            else if (GetType().Name == Constants.Bus)
            {
                var fuel = FuelQuantity - (FuelConsumptionPerKm + Constants.BusAirConditionerFuelIncrement) * distance;
                if (fuel < 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }


        protected bool IsDistanceDrivableEmpty(double distance)
        {
            var fuel = FuelQuantity - (FuelConsumptionPerKm * distance);
            if (fuel < 0)
            {
                return false;
            }
            return true;
        }

        protected bool CanItBeFillUp(double fuel)
        {
            if (TankCapacity >= fuelQuantity + fuel)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {((decimal)fuelQuantity).ToString("F2")}";
        }
    }
}
