namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode = false;
        private const double battleshipArmorThicknes = 300.00;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, battleshipArmorThicknes)
        {
            
        }

        public bool SonarMode => throw new NotImplementedException();


        public void ToggleSonarMode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
