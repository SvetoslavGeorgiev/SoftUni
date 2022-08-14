namespace PlanetWars.Models.Weapons
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;

        public Weapon(int destructionLevel, double price)
        {
            
            DestructionLevel = destructionLevel;
            Price = price;
        }

        public double Price
        {
            get { return price; }
            private set 
            { 
                price = value; 
            }
        }

        public virtual int DestructionLevel 
        {
            get => destructionLevel; 
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                else if (value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                destructionLevel = value;
            }
        }
    }
}
