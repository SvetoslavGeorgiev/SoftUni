namespace Vehicles.Models
{
    using Engine;
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm)
        {

        }

        public override string Drive(double distance)
        {
            bool IsIt = IsDistanceDrivable(distance);
            if (IsIt)
            {
                FuelQuantity -= (FuelConsumptionPerKm + Constants.CarAirConditionerFuelIncrement) * distance;
                return $"{GetType().Name} travelled {distance} km";
            }
            return $"{GetType().Name} needs refueling";
        }

        public override void Refill(double fuel)
        {
            FuelQuantity += fuel;
        }

    }
}
