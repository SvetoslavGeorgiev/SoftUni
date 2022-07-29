namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SuperCar : Car
    {
        private const double superCarFuelAvailable = 80.00;
        private const double superCarfuelConsumptionPerRace = 10.00;


        public SuperCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, superCarFuelAvailable, superCarfuelConsumptionPerRace)
        {
        }
    }
}
