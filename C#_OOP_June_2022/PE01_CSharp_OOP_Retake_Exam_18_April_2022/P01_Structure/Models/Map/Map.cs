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
            var knigths = new List<Knight>();
            var barbarians = new List<Barbarian>();


            foreach (var hero in players)
            {
                if (hero is Knight)
                {
                    knigths.Add(hero as Knight);
                }
                else
                {
                    barbarians.Add(hero as Barbarian);
                }
            }


            while (knigths.Any(x => x.IsAlive) || barbarians.Any(x => x.IsAlive))
            {

                foreach (var knight in knigths)
                {

                    foreach (var barberian in barbarians)
                    {

                        if (knight.IsAlive)
                        {
                            barberian.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }

                foreach (var barberian in barbarians)
                {

                    foreach (var knight in knigths)
                    {

                        if (barberian.IsAlive)
                        {
                            knight.TakeDamage(barberian.Weapon.DoDamage());
                        }
                    }
                }

            }


            if (knigths.Any(x => x.IsAlive))
            {
                return $"The knights took {knigths.Where(x => x.IsAlive).ToList().Count} casualties but won the battle.";
            }
            return $"The barbarians took {barbarians.Where(x => x.IsAlive).ToList().Count} casualties but won the battle.";

        }
    }
}
