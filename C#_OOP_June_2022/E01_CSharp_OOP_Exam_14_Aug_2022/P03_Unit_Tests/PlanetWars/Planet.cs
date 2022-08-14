using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars
{
    public class Planet
    {
        private string name;
        private double budget;
        private List<Weapon> weapons;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.weapons = new List<Weapon>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid planet Name");
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get
            {
                return this.budget;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget cannot drop below Zero!");
                }
                this.budget = value;
            }
        }

        public IReadOnlyCollection<Weapon> Weapons => this.weapons;

        public double MilitaryPowerRatio => this.weapons.Sum(d => d.DestructionLevel);

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void SpendFunds(double amount)
        {
            if(amount > this.Budget)
            {
                throw new InvalidOperationException($"Not enough funds to finalize the deal.");
            }
            Budget -= amount;
        }

        public void AddWeapon(Weapon weapon)
        {
            if(this.Weapons.Any(x => x.Name == weapon.Name))
            {
                throw new InvalidOperationException($"There is already a {weapon.Name} weapon.");
            }
            this.weapons.Add(weapon);
        }

        public void RemoveWeapon(string weaponName)
        {
            Weapon weapon = this.weapons.FirstOrDefault(x => x.Name == weaponName);
            this.weapons.Remove(weapon);
        }

        public void UpgradeWeapon(string weaponName)
        {
            if(!this.Weapons.Any(x => x.Name == weaponName))
            {
                throw new InvalidOperationException($"{weaponName} does not exist in the weapon repository of {this.Name}");
            }

            else
            {
                Weapon weapon = this.Weapons.FirstOrDefault(x => x.Name == weaponName);
                weapon.IncreaseDestructionLevel();
            }
        }

        public string DestructOpponent(Planet opponent)
        {
            if(opponent.MilitaryPowerRatio >= this.MilitaryPowerRatio)
            {
                throw new InvalidOperationException($"{opponent.Name} is too strong to declare war to!");
            }

            return $"{opponent.Name} is destructed!";
        }
    }
}
