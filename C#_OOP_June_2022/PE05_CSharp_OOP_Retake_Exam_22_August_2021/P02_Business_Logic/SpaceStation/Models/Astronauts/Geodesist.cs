namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Geodesist : Astronaut
    {
        private const double geodesistOxygen = 50;

        public Geodesist(string name) 
            : base(name, geodesistOxygen)
        {
        }
    }
}
