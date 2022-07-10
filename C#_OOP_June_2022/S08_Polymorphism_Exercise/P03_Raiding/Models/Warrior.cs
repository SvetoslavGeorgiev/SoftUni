namespace Raiding.Models
{
    using Raiding.Engine;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
        }

        public override int Power => Constants.WarriorPower;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
