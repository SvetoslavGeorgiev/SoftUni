namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void ConstruvtorCheckingForCreatingWarrior()
        {
            var worrior = new Warrior("Pesho", 55, 150);

            Assert.That(worrior, Is.Not.Null);
        }


        //[Test]
        //public void ConstruvtorCheckingForCreatingWarriorAndItsProperties()
        //{

        //    var worrior = new Warrior("Pesho", 55, 150);
        //    var worrior1 = new Warrior("Pesho", 55, 150);

        //    Assert.AreEqual(worrior, worrior1);
        //    Assert.AreEqual(worrior, new Warrior("Pesho", 55, 150));

        //}

        //[Test]
        //public void ConstruvtorCheckingForCreatingWarriorAndItProperties()
        //{
        //    var warriors = new Warrior[5];

        //    for (int i = 0; i < warriors.Length; i++)
        //    {
        //        warriors[i] = new Warrior($"Pesho{i}", 55 + i, 150 + i);
        //    }
        //    var worrior = warriors[3];

        //    Assert.AreEqual(new Warrior("Pesho4", 59, 154), worrior);
        //}


        [Test]
        public void ConstruvtorCheckingForCreatingWarriorAndItProperties()
        {
            var worrior = new Warrior("Pesho", 55, 150);
            var worrior1 = new Warrior("Pesho", 55, 150);

            Assert.AreEqual(worrior.Name, worrior1.Name);

            Assert.AreEqual(worrior.HP, worrior1.HP);

            Assert.AreEqual(worrior.Damage, worrior1.Damage);
        }

        [Test]
        public void CreatingWarriorWithNullEmptyOrWhiteSpacesNameShouldThrowArgumentException()
        {

            Assert.Throws<ArgumentException>(() => new Warrior(null, 55, 150));
            Assert.Throws<ArgumentException>(() => new Warrior(" ", 55, 150));
            Assert.Throws<ArgumentException>(() => new Warrior(string.Empty, 55, 150));
        }


        [Test]
        public void CreatingWarriorWitheroOrNegativeDamageShouldThrowArgumentException()
        {

            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", 0, 150));
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", -25, 150));
        }


        [Test]
        public void CreatingWarriorNegativeHpShouldThrowArgumentException()
        {

            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", 15, -25));
        }

        [Test]
        public void MinHpShouldBeMoreThen30ToAttackOtherWorriors()
        {

            var worrior = new Warrior("Pesho", 55, 30);
            var worrior1 = new Warrior("Pesho", 55, 35);

            Assert.Throws<InvalidOperationException>(() => worrior.Attack(worrior1));

            worrior = new Warrior("Pesho", 55, 5);
            worrior1 = new Warrior("Pesho", 55, 35);

            Assert.Throws<InvalidOperationException>(() => worrior.Attack(worrior1));
        }


        [Test]
        public void EnemyHpMustBeGreaterThan_MIN_ATTACK_HP_InOrderToAttackHim()
        {

            var worrior = new Warrior("Pesho", 55, 55);
            var worrior1 = new Warrior("Pesho", 55, 29);

            Assert.Throws<InvalidOperationException>(() => worrior.Attack(worrior1));

            worrior = new Warrior("Pesho", 55, 59);
            worrior1 = new Warrior("Pesho", 55, 5);

            Assert.Throws<InvalidOperationException>(() => worrior.Attack(worrior1));
        }

        [Test]
        public void WhenAttackTooStrongEnemyShoudThrowInvalidOperationException()
        {

            var worrior = new Warrior("Pesho", 55, 50);
            var worrior1 = new Warrior("Pesho", 55, 35);

            Assert.Throws<InvalidOperationException>(() => worrior.Attack(worrior1));
        }


        [Test]
        public void WhenAttackHpShouldChanche()
        {

            var worrior = new Warrior("Pesho", 55, 150);
            var worrior1 = new Warrior("Pesho", 55, 35);
            var worrior2 = new Warrior("Pesho", 55, 65);
            worrior.Attack(worrior1);
            Assert.AreEqual(95, worrior.HP);
            Assert.AreEqual(0, worrior1.HP);

            worrior.Attack(worrior2);


            Assert.AreEqual(10, worrior2.HP);


        }
    }
}