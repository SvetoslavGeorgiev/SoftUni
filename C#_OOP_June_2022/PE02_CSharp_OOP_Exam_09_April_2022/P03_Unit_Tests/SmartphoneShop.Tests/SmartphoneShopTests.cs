using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {

        [Test]
        public void ConstructorWithValidDataShouldReturnCorrectCapacity()
        {

            var shop = new Shop(5);

            Assert.AreEqual(5, shop.Capacity);
            Assert.AreEqual(0, shop.Count);

        }

        [Test]
        public void NegativeCapacityShouldThrowArgumentException()
        {

            Assert.Throws<ArgumentException>(() => new Shop(-5));

        }

        [Test]
        public void AddPhoneShouldAddItToShopCount()
        {

            var shop = new Shop(5);

            shop.Add(new Smartphone("Samsung", 78));

            Assert.AreEqual(1, shop.Count);

        }

        [Test]
        public void AddPhoneShouldthrowNewInvalidOperationExceptionIfPhoneNameAlreadyAdded()
        {

            var shop = new Shop(5);

            shop.Add(new Smartphone("Samsung", 78));

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Samsung", 25)));

        }


        [Test]
        public void AddPhoneShouldthrowNewInvalidOperationExceptionIfFullCapacity()
        {

            var shop = new Shop(2);

            shop.Add(new Smartphone("Samsung", 78));
            shop.Add(new Smartphone("Iphone", 38));

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Siemens", 25)));

        }

        [Test]
        public void RemoveShouldThrowInvalidOperationExceptionIfPhoneNameNotExist()
        {

            var shop = new Shop(2);

            shop.Add(new Smartphone("Samsung", 78));
            shop.Add(new Smartphone("Iphone", 38));

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Siemens"));

        }

        [Test]
        public void RemoveShouldRemoveAnExistingPhoneAndReduceCapacity()
        {

            var shop = new Shop(2);

            shop.Add(new Smartphone("Samsung", 78));
            shop.Add(new Smartphone("Iphone", 38));

            shop.Remove("Iphone");

            Assert.AreEqual(1, shop.Count);

        }

        [Test]
        public void TestPhoneShouldThrowInvalidOperationExceptionIfPhoneNameNotExist()
        {

            var shop = new Shop(2);

            shop.Add(new Smartphone("Samsung", 78));
            shop.Add(new Smartphone("Iphone", 38));


            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Siemens", 78));

        }

        [Test]
        public void TestPhoneShouldThrowInvalidOperationExceptionIfPhoneChargeNotEnough()
        {

            var shop = new Shop(2);

            shop.Add(new Smartphone("Samsung", 78));
            shop.Add(new Smartphone("Iphone", 38));


            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsung", 95));

        }

        [Test]
        public void TestPhoneShouldReduceChargeOfTestedPhone()
        {

            var shop = new Shop(2);

            shop.Add(new Smartphone("Samsung", 78));
            shop.Add(new Smartphone("Iphone", 38));

            shop.TestPhone("Iphone", 31);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Iphone", 8));


        }

        [Test]
        public void ChargePhoneShouldThrowInvalidOperationExceptionIfPhoneNotExist()
        {

            var shop = new Shop(2);

            shop.Add(new Smartphone("Samsung", 78));
            shop.Add(new Smartphone("Iphone", 38));


            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Siemens"));

        }

        [Test]
        public void ChargePhoneShouldGetPhoneToMaximumCharge()
        {

            var shop = new Shop(2);

            shop.Add(new Smartphone("Samsung", 78));
            shop.Add(new Smartphone("Iphone", 38));

            shop.TestPhone("Samsung", 45);

            shop.ChargePhone("Samsung");

            shop.TestPhone("Samsung", 77);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsung", 2));
        }

    }
}