namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps;
    using CarRacing.Models.Racers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.username = username;
            this.racingBehavior = racingBehavior;
            this.drivingExperience = drivingExperience;
            this.car = car;
        }

        public string Username => throw new NotImplementedException();

        public string RacingBehavior => throw new NotImplementedException();

        public int DrivingExperience => throw new NotImplementedException();

        public ICar Car => throw new NotImplementedException();

        public bool IsAvailable()
        {
            throw new NotImplementedException();
        }

        public void Race()
        {
            throw new NotImplementedException();
        }
    }
}
