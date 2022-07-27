namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Biologist : Astronaut
    {
        private const double biologistOxygen = 70.00;
        public Biologist(string name) 
            : base(name, biologistOxygen)
        {
        }

        public override void Breath()
        {
            //Oxygen -= 5;
        }
    }
}
