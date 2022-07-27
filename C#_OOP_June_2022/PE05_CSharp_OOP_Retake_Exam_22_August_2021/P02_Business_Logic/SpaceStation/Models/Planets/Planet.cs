namespace SpaceStation.Models.Planets
{
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Planet : IPlanet
    {
        private string name;
        private ICollection<string> items;

        public Planet(string name)
        {
            Name = name;
            items = new List<string>();
        }

        public ICollection<string> Items
        {
            get { return items; }
            set 
            { 
                items = value;
            }
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }
    }
}
