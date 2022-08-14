namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NuclearWeapon : Weapon
    {
        public NuclearWeapon(int destructionLevel) : base(destructionLevel, 15)
        {
        }
    }
}
