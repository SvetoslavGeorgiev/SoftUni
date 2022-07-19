namespace Heroes.Models.Weapons
{
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Mace : Weapon
    {
        private const int damage = 25;
        public Mace(string name, int durability) : base(name, durability)
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
