using Raiding.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        
        public Druid(string name) : base(name)
        {
            
        }

        public override int Power => Constants.DruidPower;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
