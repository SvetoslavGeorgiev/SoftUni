namespace PlanetWars.Models.MilitaryUnits
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        public MilitaryUnit(double cost)
        {
            this.cost = cost;
            enduranceLevel = 1;
        }



        public double Cost => throw new NotImplementedException();

        public int EnduranceLevel => throw new NotImplementedException();

        public void IncreaseEndurance()
        {
            throw new NotImplementedException();
        }
    }
}
