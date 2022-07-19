namespace Heroes.Models.Heroes
{
    using global::Heroes.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;


        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }


        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }

        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                AddWeapon(value);
            }
        }

        public bool IsAlive => Health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new ArgumentException("Weapon cannot be null.");
            }
            else if (Weapon != null)
            {
                throw new InvalidOperationException($"Hero {Name} is well-armed.");
            }
            this.weapon = weapon;


        }

        public void TakeDamage(int points)
        {
            if (Armour > points)
            {
                Armour -= points;
            }
            else if (Armour > 0)
            {
                points -= Armour;
                Armour = 0;
            }

            if (Health > points && Armour == 0)
            {
                Health -= points;
            }
            else if (Health <= points && Armour == 0)
            {
                Health = 0;
            }
        }

    }
}

