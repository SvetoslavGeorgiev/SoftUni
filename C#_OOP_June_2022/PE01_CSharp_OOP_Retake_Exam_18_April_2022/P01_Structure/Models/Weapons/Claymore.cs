namespace Heroes.Models.Weapons
{
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Claymore : Weapon
    {
        private int damage;
        public Claymore(string name, int durability) : base(name, durability)
        {
            damage = 20;
        }



        public override int DoDamage()
        {
            Durability--;
            if (Durability == 0)
            {
                return 0;
            }
            return damage;
        }
    }
}
