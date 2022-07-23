namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode = false;
        private const double submarineArmorThicknes = 200.00;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, submarineArmorThicknes)
        {
            
        }

        public bool SubmergeMode => throw new NotImplementedException();

        
        public void ToggleSubmergeMode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
