namespace Vehicles.Models
{
    using Engine;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm)
        {
        }

        public override string Drive(double distance)
        {
            bool IsIt = IsDistanceDrivable(distance);
            if (IsIt)
            {
                FuelQuantity -= (FuelConsumptionPerKm + Constants.TruckAirConditionerFuelIncrement) * distance;
                return $"{GetType().Name} travelled {distance} km";
            }
            return $"{GetType().Name} needs refueling";
        }

        public override void Refill(double fuel)
        {
            FuelQuantity += fuel * Constants.TruckFuelPercentage;
        }

        
    }
}
