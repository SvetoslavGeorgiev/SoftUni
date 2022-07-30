namespace FakeAxeAndDummy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hero
    {
        private string name;
        private int experience;
        private IWeapon weapon;

        public Hero(string name, IWeapon weapon)
        {
            Name = name;
            Experience = 0;
            Weapon = weapon;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Experience
        {
            get { return experience; }
            private set { experience = value; }
        }

        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                weapon = value;
            }
        }

        public void Attack(ITarget target)
        {
            Weapon.Attack(target);

            if (target.IsDead())
            {
                experience += target.GiveExperience();
            }
        }
    }
}
