namespace Heroes.Models.Map
{
    using Models.Contracts;
    using Models.Heroes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = new List<Knight>();
            var barbarians = new List<Barbarian>();


            foreach (var hero in players)
            {
                if (hero is Knight && hero.Weapon != null && hero.IsAlive)
                {

                    knights.Add(hero as Knight);

                }
                else if (hero is Barbarian && hero.Weapon != null && hero.IsAlive)
                {

                    barbarians.Add(hero as Barbarian);
                }
            }

            var startBattle = false;
            while(knights.Any() && barbarians.Any())
            {
                startBattle = true;
                foreach (var knight in knights)
                {

                    foreach (var barbarian in barbarians)
                    {

                        if (knight.IsAlive && barbarian.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {

                    foreach (var knight in knights)
                    {

                        if (barbarian.IsAlive && knight.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }

                if (knights.All(x => x.IsAlive == false))
                {
                    break;
                }
                else if (barbarians.All(x => x.IsAlive == false))
                {
                    break;
                }

            }

            if (startBattle)
            {
                if (knights.Any(x => x.IsAlive))
                {

                    return $"The knights took {knights.Where(x => !x.IsAlive).ToList().Count} casualties but won the battle.";
                }

                return $"The barbarians took {barbarians.Where(x => !x.IsAlive).ToList().Count} casualties but won the battle.";
            }
            return null;
        }
    }
}
