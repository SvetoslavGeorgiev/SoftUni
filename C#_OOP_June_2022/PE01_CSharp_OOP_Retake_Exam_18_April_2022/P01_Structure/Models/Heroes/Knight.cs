namespace Heroes.Models.Heroes
{
    using Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Knight : Hero
    {
        public Knight(string name, int health, int armour) : base(name, health, armour)
        {
        }
    }
}
