namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProfessionalRacer : Racer
    {
        private const int professionalRacerDrivingExperience = 30;
        private const string professionalRacerracingBehavior = "strict";
        public ProfessionalRacer(string username, ICar car) 
            : base(username, professionalRacerracingBehavior, professionalRacerDrivingExperience, car)
        {

        }
    }
}
