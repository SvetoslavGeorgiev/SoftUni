namespace Vehicles.Models
{
    
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Vehicles.Contracts;
    using Vehicles.Engine;

    public class Bus : Vehicle, IDriveEmpty
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            bool IsIt = IsDistanceDrivable(distance);
            if (IsIt)
            {
                FuelQuantity -= (FuelConsumptionPerKm + Constants.BusAirConditionerFuelIncrement) * distance;
                return $"{GetType().Name} travelled {distance} km";
            }
            return $"{GetType().Name} needs refueling";
        }

        public override string DriveEmpry(double distance)
        {
            bool IsIt = IsDistanceDrivableEmpty(distance);
            if (IsIt)
            {
                FuelQuantity -= FuelConsumptionPerKm * distance;
                return $"{GetType().Name} travelled {distance} km";
            }
            return $"{GetType().Name} needs refueling";
        }

        public override void Refill(double fuel)
        {
            var itCan = CanItBeFillUp(fuel);
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (!itCan)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }
            FuelQuantity += fuel;
        }
    }
}
