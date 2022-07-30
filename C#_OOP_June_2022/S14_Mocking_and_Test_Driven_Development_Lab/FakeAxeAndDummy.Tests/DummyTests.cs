namespace FakeAxeAndDummy.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FakeAxeAndDummy;
    using NUnit.Framework;


    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            
            dummy.TakeAttack(axe.AttackPoints);

            Assert.That(dummy.Health, Is.EqualTo(0), "Axe Durability doesn't change after attach.");
        }


        [Test]
        public void DummyLosesHealthIfAttacked_v2()
        {

            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(0), "Axe Durability doesn't change after attach.");
        }

        [Test]
        public void TestAttackWithZeroHealth()
        {
            dummy.TakeAttack(axe.AttackPoints);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(axe.AttackPoints));
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            dummy = new Dummy(12, 10);

            dummy.TakeAttack(axe.AttackPoints);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {

            dummy.TakeAttack(axe.AttackPoints);

            Assert.That(() => dummy.GiveExperience(), Is.EqualTo(10));
        }

    }
}
