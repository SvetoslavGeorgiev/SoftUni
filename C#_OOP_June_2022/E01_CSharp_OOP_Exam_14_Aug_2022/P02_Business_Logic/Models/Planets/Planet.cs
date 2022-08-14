namespace PlanetWars.Models.Planets
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private ICollection<IMilitaryUnit> army;
        private ICollection<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower => GetValue();

        private double GetValue()
        {
            double totalAmount = army.Sum(x => x.EnduranceLevel) + weapons.Sum(x => x.DestructionLevel);

            if (army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount += totalAmount * 0.3;
            }
            if (weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                totalAmount += totalAmount * 0.45;
            }
            return Math.Round(totalAmount, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => (IReadOnlyCollection<IMilitaryUnit>)army;

        public IReadOnlyCollection<IWeapon> Weapons => (IReadOnlyCollection<IWeapon>)weapons;

        public void AddUnit(IMilitaryUnit unit)
        {
            army.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            var units = army.Count == 0 ? "No units" : $"{string.Join(", ", army.Select(x => x.GetType().Name).ToList())}";
            var equipment = weapons.Count == 0 ? "No weapons" : $"{string.Join(", ", weapons.Select(x => x.GetType().Name).ToList())}";

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine($"--Forces: {units}");
            sb.AppendLine($"--Combat equipment: {equipment}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
