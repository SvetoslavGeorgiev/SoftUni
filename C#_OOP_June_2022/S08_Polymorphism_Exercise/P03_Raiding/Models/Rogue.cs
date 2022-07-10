namespace Raiding.Models
{
    using Raiding.Engine;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
        }

        public override int Power => Constants.RoguePower;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
