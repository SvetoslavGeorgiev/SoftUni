namespace Heroes.Models.Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models.Contracts;

    public class Barbarian : Hero
    {
        public Barbarian(string name, int health, int armour) : base(name, health, armour)
        {
        }

    }
}
