namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Models.Weapons.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;

        public Weapon(double price, int destructionLevel)
        {
            this.price = price;
            this.destructionLevel = destructionLevel;
        }

        public double Price => throw new NotImplementedException();

        public int DestructionLevel => throw new NotImplementedException();
    }
}
