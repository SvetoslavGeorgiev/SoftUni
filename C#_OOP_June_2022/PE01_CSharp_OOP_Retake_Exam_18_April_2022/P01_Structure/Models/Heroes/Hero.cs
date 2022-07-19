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
        private bool isAlive;
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
                //if (value == null)
                //{
                //    throw new ArgumentException("Weapon cannot be null.");
                //}
                AddWeapon(value);
            }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            private set 
            {
                if (Health > 0)
                {
                    isAlive = true;
                }
                else
                {
                    isAlive = false;
                }
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new ArgumentException("Weapon cannot be null.");
            }
            if (Weapon == null)
            {
                this.weapon = weapon;
            }
            
        }

        public void TakeDamage(int points)
        {
            if (Armour >= 0)
            {
                Armour -= points;
            }

            if (armour <= 0)
            {
                Health -= Armour;
                Armour = 0;
            }

            if (Health <= 0)
            {
                isAlive = false;
            }

        }


        //private void IsAliveOrDead()
        //{
        //    if (Health > 0)
        //    {
        //        isAlive = true;
        //    }
        //    else
        //    {
        //        isAlive = false;
        //    }
        //}
    
    }

    
}

