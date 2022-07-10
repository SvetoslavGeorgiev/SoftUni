using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void TestAttackLoosesWeaponDurability()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attach.");
        }

        [Test]
        public void TestAttackWithZeroWeaponDurability()
        {
            Axe axe = new Axe(10, 1);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(new Dummy(100, 100)));
        }
    }
}