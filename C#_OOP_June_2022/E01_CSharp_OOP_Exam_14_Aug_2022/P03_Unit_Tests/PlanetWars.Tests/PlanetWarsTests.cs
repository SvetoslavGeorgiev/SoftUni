using NUnit.Framework;
using System;
using System.ComponentModel;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {



            [Test]
            public void ConstructorShouldReturnRightObject()
            {
                var planet = new Planet("Pesho", 1000.00);

                Assert.IsNotNull(planet);
                Assert.AreEqual("Pesho", planet.Name);
                Assert.AreEqual(1000, planet.Budget);
                Assert.AreEqual(0, planet.Weapons.Count);
            }


            [Test]
            public void ConstructorShouldThrowArgumentExceptionIfNameIsNullOrEmpty()
            {
                Assert.Throws<ArgumentException>(() =>  new Planet("", 1000.00));
                Assert.Throws<ArgumentException>(() =>  new Planet(null, 1000.00));

            }


            [Test]
            public void ConstructorShouldThrowArgumentExceptionIfBudgetIsNegatiwve()
            {
                Assert.Throws<ArgumentException>(() => new Planet("Pesho", -1000.00));
                Assert.Throws<ArgumentException>(() => new Planet("Pesho", -0.01));

            }

            [Test]
            public void MilitaryPowerRatioShouldRetyrnCorrectSum()
            {
                var planet = new Planet("Pesho", 1000);

                var weapon = new Weapon("Boom", 25, 6);
                var weapon1 = new Weapon("BigBoom", 150, 15);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                Assert.AreEqual(21, planet.MilitaryPowerRatio);
                

            }

            [Test]
            public void WeaponConstructorShouldThrowExeptionIfPriceIsNegative()
            {
                
                Assert.Throws<ArgumentException>(() => new Weapon("Boom", -10.00, 5));


            }

            [Test]
            public void IncreaseDestructionLevelShouldIcreaseDestructionLevel()
            {

                var weapon = new Weapon("Boom", 25, 6);
                var weapon1 = new Weapon("BigBoom", 150, 15);

                weapon.IncreaseDestructionLevel();
                weapon1.IncreaseDestructionLevel();

                Assert.AreEqual(7, weapon.DestructionLevel);
                Assert.AreEqual(16, weapon1.DestructionLevel);


            }

            [Test]
            public void IsNuclearShouldReturnCorrectIsNuclearOrNot()
            {

                var weapon = new Weapon("Boom", 25, 6);
                var weapon1 = new Weapon("BigBoom", 150, 15);

                
                Assert.IsFalse(weapon.IsNuclear);
                Assert.IsTrue(weapon1.IsNuclear);


            }

            [Test]
            public void ProfitSholdIcreaceBugetOfThePlanetByGivenAmount()
            {

                var planet = new Planet("Pesho", 1000.00);

                planet.Profit(50.05);


                Assert.AreEqual(1050.05, planet.Budget);
            }



            [Test]
            public void SpendFundsShouldDecreaceBugetOfThePlanetBy()
            {
                var planet = new Planet("Pesho", 1000.00);

                planet.SpendFunds(55.48);

                Assert.AreEqual(944.52, planet.Budget);

            }

            [Test]
            public void SpendFundsShouldThrowInvalidOperationExceptionIfSpendingAmountIsBiggerThenBuget()
            {
                var planet = new Planet("Pesho", 50.00);

                

                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(55.48), "Not enough funds to finalize the deal.");

            }


            [Test]
            public void AddWeaponShouldReturnCorrectCountOFCorrectAddedWeapons()
            {
                var planet = new Planet("Pesho", 1000);

                var weapon = new Weapon("Boom", 25, 6);
                var weapon1 = new Weapon("BigBoom", 150, 15);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);


                Assert.AreEqual(2, planet.Weapons.Count);

            }

            [Test]
            public void AddWeaponShouldThrowInvalidOperationExceptionIfWeaponWithThatNameExist()
            {
                var planet = new Planet("Pesho", 1000);

                var weapon = new Weapon("Boom", 25, 6);
                var weapon1 = new Weapon("BigBoom", 150, 15);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(new Weapon("Boom", 22, 6)), "$There is already a Boom weapon.");

            }

            [Test]
            public void RemoveWeaponShouldDecreaceWeaponsCount()
            {
                var planet = new Planet("Pesho", 1000);

                var weapon = new Weapon("Boom", 25, 6);
                var weapon1 = new Weapon("BigBoom", 150, 15);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                Assert.AreEqual(2, planet.Weapons.Count);

                planet.RemoveWeapon("Boom");

                Assert.AreEqual(1, planet.Weapons.Count);


                planet.RemoveWeapon("BoomBoom");

                Assert.AreEqual(1, planet.Weapons.Count);

            }

            [Test]
            public void RemoveWeaponShouldDoNotingIfNameOfTheWeaponDoesntExist()
            {
                var planet = new Planet("Pesho", 1000);

                var weapon = new Weapon("Boom", 25, 6);
                var weapon1 = new Weapon("BigBoom", 150, 15);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                Assert.AreEqual(2, planet.Weapons.Count);

                
                planet.RemoveWeapon("BoomBoom");

                Assert.AreEqual(2, planet.Weapons.Count);

            }

            [Test]
            public void UpgradeWeaponShouldIncreaseDestructionLevelIfWeaponExist()
            {
                var planet = new Planet("Pesho", 1000);

                var weapon = new Weapon("Boom", 25, 9);
                var weapon1 = new Weapon("BigBoom", 150, 15);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                Assert.IsFalse(weapon.IsNuclear);

                planet.UpgradeWeapon("Boom");

                Assert.IsTrue(weapon.IsNuclear);

            }

            [Test]
            public void UpgradeWeaponShouldThrowInvalidOperationExceptionIfNameOfTheWeaponDoesntExist()
            {
                var planet = new Planet("Pesho", 1000);

                var weapon = new Weapon("Boom", 25, 9);
                var weapon1 = new Weapon("BigBoom", 150, 15);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("Bom"), $"Bom does not exist in the weapon repository of Pesho");

            }

            [Test]
            public void DestructOpponentShouldReturnCorrectSetring()
            {
                var planet = new Planet("Pesho", 1000);

                var weapon = new Weapon("Boom", 25, 9);
                var weapon1 = new Weapon("BigBoom", 150, 15);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                var planet1 = new Planet("Gosho", 1000);

                var weapon2 = new Weapon("Boom", 25, 7);
                var weapon3 = new Weapon("BigBoom", 150, 7);

                planet1.AddWeapon(weapon2);
                planet1.AddWeapon(weapon3);

                Assert.AreEqual($"Gosho is destructed!", planet.DestructOpponent(planet1));

            }

            [Test]
            public void DestructOpponentShouldThrowInvalidOperationExceptionIfOpponetIsStronger()
            {
                var planet = new Planet("Pesho", 1000);

                var weapon = new Weapon("Boom", 25, 9);
                var weapon1 = new Weapon("BigBoom", 150, 15);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                var planet1 = new Planet("Gosho", 1000);

                var weapon2 = new Weapon("Boom", 25, 12);
                var weapon3 = new Weapon("BigBoom", 150, 20);

                planet1.AddWeapon(weapon2);
                planet1.AddWeapon(weapon3);

                Assert.Throws<InvalidOperationException>(() => planet.DestructOpponent(planet1), "Gosho is too strong to declare war to!");

            }
        }
    }
}
