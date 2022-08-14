using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars
{
    public class Weapon
    {
        private double price;

        public Weapon(string name, double price, int destructionLevel)
        {
            Name = name;
            Price = price;
            DestructionLevel = destructionLevel;
        }

        public string Name { get; set; }
        public double Price 
        { 
            get => price;
            set 
            { 
                if(value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                price = value; 
            } 
        }
        public int DestructionLevel { get; set; }

        public void IncreaseDestructionLevel()
        {
            DestructionLevel++;
        }

        public bool IsNuclear => this.DestructionLevel >= 10;
    }
}
