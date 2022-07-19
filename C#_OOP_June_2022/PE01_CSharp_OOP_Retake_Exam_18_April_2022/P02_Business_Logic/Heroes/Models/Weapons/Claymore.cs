namespace Heroes.Models.Weapons
{
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Claymore : Weapon
    {
        private const int damage = 20;
        public Claymore(string name, int durability) : base(name, durability)
        {
           
        }

        public override int DoDamage()
        {

            if (Durability > 0)
            {
                Durability--;
                return damage;
            }
            return 0;
            
        }
    }
}
