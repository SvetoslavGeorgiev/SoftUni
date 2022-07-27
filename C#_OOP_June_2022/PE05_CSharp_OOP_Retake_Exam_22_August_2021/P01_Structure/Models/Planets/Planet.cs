namespace SpaceStation.Models.Planets
{
    using SpaceStation.Models.Planets.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Planet : IPlanet
    {
        private string name;
        private readonly ICollection<Planet> items;

        public Planet(string name)
        {
            this.name = name;
            items = new List<Planet>();
        }

        public ICollection<string> Items => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();
    }
}
