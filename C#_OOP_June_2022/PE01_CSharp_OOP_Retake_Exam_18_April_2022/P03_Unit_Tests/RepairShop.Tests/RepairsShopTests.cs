using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {

            [Test]
            public void ComstrictorWithValidDataShoulReturnValidData()
            {

                var garage = new Garage("PriPesho", 10);

                Assert.AreEqual("PriPesho", garage.Name);
                Assert.AreEqual(10, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void ComstrictorWithNullorEmptyNameShouldThrowArgumentNullException()
            {

               

                Assert.Throws<ArgumentNullException>(() => new Garage("", 10));
                Assert.Throws<ArgumentNullException>(() => new Garage(null, 10));

            }

            [Test]
            public void ComstrictorWithZeroOrNegativeShouldThrowArgumentException()
            {

                

                Assert.Throws<ArgumentException>(() => new Garage("PriPesho", 0));
                Assert.Throws<ArgumentException>(() => new Garage("PriPesho", -5));

            }

            [Test]
            public void AddCarShoudReturnCorectValue()
            {

                var garage = new Garage("PriPesho", 10);

                garage.AddCar(new Car("Opel", 15));

                Assert.AreEqual(1, garage.CarsInGarage);

            }

            [Test]
            public void AddCarShoudThrowInvalidOperationExceptionIfCarsAreMoreThenMechanics()
            {

                var garage = new Garage("PriPesho", 1);

                garage.AddCar(new Car("Opel", 15));

                Assert.Throws<InvalidOperationException>(() => garage.AddCar(new Car("Opel", 10)));

            }


            [Test]
            public void FixCarShoudThrowInvalidOperationExceptionIfCarsNotInList()
            {

                var garage = new Garage("PriPesho", 1);

                garage.AddCar(new Car("Opel", 15));

                Assert.Throws<InvalidOperationException>(() => garage.FixCar("Volvo"));

            }

            [Test]
            public void FixCarIfExistShoudReturnZeroProblems()
            {

                var garage = new Garage("PriPesho", 1);

                garage.AddCar(new Car("Opel", 15));

                garage.FixCar("Opel");

                garage.RemoveFixedCar();

                Assert.AreEqual(0, garage.CarsInGarage);

            }

            [Test]
            public void FixCarShouldThrowInvalidOperationExceptionIfFixedCarsAreZero()
            {

                var garage = new Garage("PriPesho", 1);

                garage.AddCar(new Car("Opel", 15));



                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());

            }

            [Test]
            public void ReprotShouldReturnCorrectMessage()
            {

                var garage = new Garage("PriPesho", 4);

                garage.AddCar(new Car("Opel", 15));
                garage.AddCar(new Car("Volvo", 10));


                var expexted = $"There are 2 which are not fixed: Opel, Volvo.";


                Assert.AreEqual(expexted, garage.Report());

            }
        }
    }
}