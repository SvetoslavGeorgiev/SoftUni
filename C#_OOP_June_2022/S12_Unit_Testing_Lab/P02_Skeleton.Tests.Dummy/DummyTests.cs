using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(axe.AttackPoints);

            Assert.That(dummy.Health, Is.EqualTo(0), "Axe Durability doesn't change after attach.");
        }


        [Test]
        public void DummyLosesHealthIfAttacked_v2()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(0), "Axe Durability doesn't change after attach.");
        }

        [Test]
        public void TestAttackWithZeroHealth()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(axe.AttackPoints);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(axe.AttackPoints));
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(12, 10);

            dummy.TakeAttack(axe.AttackPoints);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(axe.AttackPoints);

            Assert.That(() => dummy.GiveExperience(), Is.EqualTo(10));
        }
    }
}