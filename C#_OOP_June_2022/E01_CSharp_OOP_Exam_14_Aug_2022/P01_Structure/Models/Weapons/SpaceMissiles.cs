namespace PlanetWars.Models.Weapons
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SpaceMissiles : Weapon
    {
        public SpaceMissiles(int destructionLevel) : base(8.75, destructionLevel)
        {
        }
    }
}
