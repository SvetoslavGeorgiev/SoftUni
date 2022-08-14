namespace PlanetWars.Models.Planets
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private ICollection<IMilitaryUnit> army;
        private ICollection<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            this.name = name;
            this.budget = budget;
            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }

        public string Name => throw new NotImplementedException();

        public double Budget => throw new NotImplementedException();

        public double MilitaryPower => throw new NotImplementedException();

        public IReadOnlyCollection<IMilitaryUnit> Army => throw new NotImplementedException();

        public IReadOnlyCollection<IWeapon> Weapons => throw new NotImplementedException();

        public void AddUnit(IMilitaryUnit unit)
        {
            throw new NotImplementedException();
        }

        public void AddWeapon(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public string PlanetInfo()
        {
            throw new NotImplementedException();
        }

        public void Profit(double amount)
        {
            throw new NotImplementedException();
        }

        public void Spend(double amount)
        {
            throw new NotImplementedException();
        }

        public void TrainArmy()
        {
            throw new NotImplementedException();
        }
    }
}
