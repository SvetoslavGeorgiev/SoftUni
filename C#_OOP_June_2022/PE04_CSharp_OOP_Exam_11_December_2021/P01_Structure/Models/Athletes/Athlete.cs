namespace Gym.Models.Athletes
{
    using Gym.Models.Athletes.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;
        private int stamina;

        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.fullName = fullName;
            this.motivation = motivation;
            this.numberOfMedals = numberOfMedals;
            this.stamina = stamina;
        }

        public string FullName => throw new NotImplementedException();

        public string Motivation => throw new NotImplementedException();

        public int Stamina => throw new NotImplementedException();

        public int NumberOfMedals => throw new NotImplementedException();

        public abstract void Exercise();
    }
}
