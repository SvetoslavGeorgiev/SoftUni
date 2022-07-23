namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;
        private const double submarineArmorThicknes = 200.00;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, submarineArmorThicknes)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode
        {
            get => submergeMode;
            private set
            {
                submergeMode = value;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < submarineArmorThicknes)
            {

                ArmorThickness = 200.00;

            }
        }


        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == true)
            {
                SubmergeMode = false;
                MainWeaponCaliber -= 40.00;
                Speed += 4.00;
            }
            else
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40.00;
                Speed -= 4.00;
            }
        }

        public override string ToString()
        {
            var submergeMode = SubmergeMode == true ? " *Submerge mode: ON" : " *Submerge mode: OFF";

            return base.ToString() + Environment.NewLine + submergeMode;
        }
    }
}
