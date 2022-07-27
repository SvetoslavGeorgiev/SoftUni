namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            this.name = name;
            this.oxygen = oxygen;
        }

        public string Name => throw new NotImplementedException();

        public double Oxygen => throw new NotImplementedException();

        public bool CanBreath => throw new NotImplementedException();

        public IBag Bag => throw new NotImplementedException();

        public virtual void Breath()
        {
            throw new NotImplementedException();
        }
    }
}
