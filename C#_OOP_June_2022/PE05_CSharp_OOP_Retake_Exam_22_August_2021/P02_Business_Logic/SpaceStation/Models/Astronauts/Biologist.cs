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

        public override bool CanBreath => Oxygen >= 5.00;

        public override void Breath()
        {
            if (Oxygen - 5 <= 0)
            {
                Oxygen = 0;
            }
            else
            {

                Oxygen -= 5;
            }
        }
    }
}
