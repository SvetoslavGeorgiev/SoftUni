namespace Raiding.Models
{
    using Raiding.Engine;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {

        }

        public override int Power => Constants.PaladinPower;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
