namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Meteorologist : Astronaut
    {
        private const double meteorologistOxygen = 90;
        public Meteorologist(string name) 
            : base(name, meteorologistOxygen)
        {
        }
    }
}
