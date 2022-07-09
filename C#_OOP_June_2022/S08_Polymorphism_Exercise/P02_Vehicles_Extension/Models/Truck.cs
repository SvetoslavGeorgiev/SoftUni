namespace Vehicles.Models
{
    using Engine;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            bool isIt = IsDistanceDrivable(distance);
            if (isIt)
            {
                FuelQuantity -= (FuelConsumptionPerKm + Constants.TruckAirConditionerFuelIncrement) * distance;
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
            FuelQuantity += fuel * Constants.TruckFuelPercentage;
        }

        
    }
}
