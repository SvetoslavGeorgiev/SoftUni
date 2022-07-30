namespace FakeAxeAndDummy.Tests
{
    using FakeAxeAndDummy;
    using NUnit.Framework;
    using System;

    public class AxeTests
    {
        [Test]
        public void TestAttackLoosesWeaponDurability()
        {
            var axe = new Axe(10, 10);
            var dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attach.");
        }

        [Test]
        public void TestAttackWithZeroWeaponDurability()
        {
            var axe = new Axe(10, 1);
            var dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(new Dummy(100, 100)));
        }
    }
}