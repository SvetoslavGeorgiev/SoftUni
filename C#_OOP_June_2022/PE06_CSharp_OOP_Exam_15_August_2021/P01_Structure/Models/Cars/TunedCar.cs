namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TunedCar : Car
    {
        private const double tunedCarFuelAvailable = 65.00;
        private const double tunedCarfuelConsumptionPerRace = 7.50;
        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, tunedCarFuelAvailable, tunedCarfuelConsumptionPerRace)
        {
        }
    }
}
