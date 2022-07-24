namespace Gym.Models.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoxingGloves : Equipment
    {

        private const double boxingGlovesWeight = 227.00;
        private const decimal boxingGlovesPrice = 120;

        public BoxingGloves() 
            : base(boxingGlovesWeight, boxingGlovesPrice)
        {

        }
    }
}
