namespace Gym.Models.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Kettlebell : Equipment
    {
        private const double kettlebellWeight = 10_000.00;
        private const decimal kettlebellPrice = 80;

        public Kettlebell()
            : base(kettlebellWeight, kettlebellPrice)
        {

        }
    }
}
