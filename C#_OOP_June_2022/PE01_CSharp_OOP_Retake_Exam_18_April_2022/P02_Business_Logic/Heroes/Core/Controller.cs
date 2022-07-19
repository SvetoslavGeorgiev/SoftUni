namespace Heroes.Core
{
    using Heroes.Core.Contracts;
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Models.Map;
    using Heroes.Models.Weapons;
    using Heroes.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var hero = heroes.FindByName(heroName);
            var weapon = weapons.FindByName(weaponName);

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            var type = weapon is Claymore ? $"{nameof(Claymore).ToLower()}" : $"{nameof(Mace).ToLower()}";

            return $"Hero {heroName} can participate in battle using a {type}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = null;
            if (type != nameof(Knight) && type != nameof(Barbarian))
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
            else if (type == nameof(Knight))
            {
                hero = new Knight(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Sir {name} to the collection.";
            }
            else// if (type == nameof(Barbarian))
            {
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Barbarian {name} to the collection.";
            }
            

        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = null;
            if (type == nameof(Mace))
            {
                weapon = new Mace(name, durability);
                weapons.Add(weapon);
                return $"A {type.ToLower()} {weapon.Name} is added to the collection.";
            }
            else if (type == nameof(Claymore))
            {
                weapon = new Claymore(name, durability);
                weapons.Add(weapon);
                return $"A {type.ToLower()} {weapon.Name} is added to the collection.";
            }

            throw new InvalidOperationException("Invalid hero type.");

        }

        public string HeroReport()
        {
            var sb = new StringBuilder();
            foreach (IHero hero in heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                sb.AppendLine(hero.Weapon == null ? $"--Weapon: Unarmed" : $"--Weapon: {hero.Weapon.Name}");

            }
            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            var map = new Map();

            var result = map.Fight(heroes.Models as ICollection<IHero>);
            return result;
        }
    }
}
