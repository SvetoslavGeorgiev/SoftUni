namespace Raiding.Engine
{
    using Raiding.Contracts;
    using Raiding.Models;
    using System.Collections;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class Raid : IRaid
    {
        private ICollection<BaseHero> heroes;

        public Raid(int capacity)
        {
            heroes = new List<BaseHero>(capacity);
        }

        public IReadOnlyCollection<BaseHero> Heroes
        {
            get => (IReadOnlyCollection<BaseHero>)heroes;
        }

        public void AddHero(BaseHero hero)
        {
            heroes.Add(hero);
        }

        public void ForEach()
        {
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
        }

        public string GetWinOrLose(int bossPower)
        {
            if (Heroes.Sum(x => x.Power) >= bossPower)
            {
                return Constants.Win;
            }
            return Constants.Lose;
        }
    }
}
