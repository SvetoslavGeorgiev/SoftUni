namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StreetRacer : Racer
    {
        private const int streetRacerDrivingExperience = 10;
        private const string streetRacerRacerracingBehavior = "aggressive";
        public StreetRacer(string username, ICar car)
            : base(username, streetRacerRacerracingBehavior, streetRacerDrivingExperience, car)
        {

        }
    }
}
