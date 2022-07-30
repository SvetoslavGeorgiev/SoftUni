namespace FakeAxeAndDummy.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    public class HeroTests
    {

        [Test]
        public void TestHeroConstructor()
        {
            var axe = new Axe(10 , 10); 

            var hero = new Hero("Pesho" , axe);


            Assert.Multiple(() =>
            {
                Assert.That(hero.Name, Is.EqualTo("Pesho"));
                Assert.That(hero.Experience, Is.EqualTo(0));
                Assert.That(hero.Weapon, !Is.Null);
            });
        }

        [Test]
        public void TestAttackSouldDecreaseDummyHealthAndHeroWeaponDurabilityAndInceaseHeroExperiance()
        {
            var axe = new Axe(10, 10);
            var hero = new Hero("Pesho", axe);
            var dummy = new Dummy(10, 44);

            hero.Attack(dummy);



            Assert.Multiple(() =>
            {
                Assert.That(dummy.Health, Is.EqualTo(0));
                Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
                Assert.That(hero.Experience, Is.EqualTo(44));
            });
        }
    }
}
