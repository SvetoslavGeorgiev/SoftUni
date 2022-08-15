namespace PlanetWars.Core
{
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private PlanetRepository planetRepository;
        //private UnitRepository unitRepository;
        //private WeaponRepository weaponRepository;

        public Controller()
        {
            planetRepository = new PlanetRepository();
            //unitRepository = new UnitRepository();
            //weaponRepository = new WeaponRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit militaryUnit;

            if (planetRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != nameof(AnonymousImpactUnit) && unitTypeName != nameof(SpaceForces) && unitTypeName != nameof(StormTroopers))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            var planet = planetRepository.FindByName(planetName);

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                militaryUnit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                militaryUnit = new SpaceForces();
            }
            else
            {
                militaryUnit = new StormTroopers();
            }
            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IWeapon weapon;

            if (planetRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var planet = planetRepository.FindByName(planetName);

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != nameof(BioChemicalWeapon) && weaponTypeName != nameof(NuclearWeapon) && weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);

        }

        public string CreatePlanet(string name, double budget)
        {
            var planet = planetRepository.FindByName(name);

            if (planet != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            var newPlanet = new Planet(name, budget);

            planetRepository.AddItem(newPlanet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {


            var sb = new StringBuilder();


            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planetRepository.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planet1 = planetRepository.FindByName(planetOne);
            var planet2 = planetRepository.FindByName(planetTwo);

            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (planet1.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)) && planet2.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)) ||
                    planet1.Weapons.All(x => x.GetType().Name != nameof(NuclearWeapon)) && planet2.Weapons.All(x => x.GetType().Name != nameof(NuclearWeapon)))
                {

                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);

                    return String.Format(OutputMessages.NoWinner);
                }
                else if (planet1.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet1.Profit(planet2.Budget / 2);
                    planet1.Profit(planet2.Army.Sum(x => x.Cost) + planet2.Weapons.Sum(x => x.Price));
                    planetRepository.RemoveItem(planetTwo);

                    return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else
                {
                    planet2.Spend(planet2.Budget / 2);
                    planet2.Profit(planet1.Budget / 2);
                    planet2.Profit(planet1.Army.Sum(x => x.Cost) + planet1.Weapons.Sum(x => x.Price));
                    planetRepository.RemoveItem(planetOne);
                    return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
                
            }
            else if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                planet1.Spend(planet1.Budget / 2);
                planet1.Profit(planet2.Budget / 2);
                planet1.Profit(planet2.Army.Sum(x => x.Cost) + planet2.Weapons.Sum(x => x.Price));
                planetRepository.RemoveItem(planetTwo);
                return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else
            {
                planet2.Spend(planet2.Budget / 2);
                planet2.Profit(planet1.Budget / 2);
                planet2.Profit(planet1.Army.Sum(x => x.Cost) + planet1.Weapons.Sum(x => x.Price));
                planetRepository.RemoveItem(planetOne);
                return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }

        }

        public string SpecializeForces(string planetName)
        {
            if (planetRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            var planet = planetRepository.FindByName(planetName);

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);

            planet.TrainArmy();

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}