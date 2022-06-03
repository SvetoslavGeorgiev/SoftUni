using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car()
        {
            TravelledDistance = 0;
        }

        public Car(string make, double fuelQuantity, double fuelConsumptionPerKilometer)
        : this()
        {
            Make = make;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        


        public string Make { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public void Drive(double distance)
        {
            var fuelneeded = distance * FuelConsumptionPerKilometer ;

            if (fuelneeded <= FuelQuantity)
            {
                FuelQuantity -= fuelneeded;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public string WhoAmI()
        {

            var result = $"{Make} {FuelQuantity:F2} {TravelledDistance}";

            return result;
        }

    }
}
