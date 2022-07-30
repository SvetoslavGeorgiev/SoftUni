namespace FakeAxeAndDummy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Axe : IWeapon
    {
        private int attackPoints;
        private int durabilityPoints;

        public Axe(int attack, int durability)
        {
            AttackPoints = attack;
            DurabilityPoints = durability;
        }

        public int AttackPoints
        {
            get { return attackPoints; }
            set { attackPoints = value; }
        }

        public int DurabilityPoints
        {
            get { return durabilityPoints; }
            set { durabilityPoints = value; }
        }

        public void Attack(ITarget target)
        {
            if (durabilityPoints <= 0)
            {
                throw new InvalidOperationException("Axe is broken.");
            }

            target.TakeAttack(attackPoints);
            durabilityPoints -= 1;
        }
    }
}
