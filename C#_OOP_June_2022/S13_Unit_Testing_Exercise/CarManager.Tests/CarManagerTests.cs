namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {

        [Test]
        public void CheckingConstructorForValidData()
        {

            Car car = new Car("Opel", "Astra", 0.05, 70);
            Car car1 = new Car("Opel", "Astra", 0.05, 70);


            Assert.IsNotNull(car);
            Assert.AreEqual(car1.Make, car.Make);
            Assert.AreEqual(car1.Model, car.Model);
            Assert.AreEqual(car1.FuelConsumption, car.FuelConsumption);
            Assert.AreEqual(car1.FuelCapacity, car.FuelCapacity);
            Assert.AreEqual(car1.FuelAmount, car.FuelAmount);
        }


        [Test]
        public void MakeShouldntBeNullOrEmpty()
        {

            Assert.Throws<ArgumentException>(() => new Car(string.Empty, "Astra", 0.05, 70));
            Assert.Throws<ArgumentException>(() => new Car(null, "Astra", 0.05, 70));
            
        }

        [Test]
        public void ModelShouldntBeNullOrEmpty()
        {

            Assert.Throws<ArgumentException>(() => new Car("Opel", string.Empty, 0.05, 70));
            Assert.Throws<ArgumentException>(() => new Car("Opel", null, 0.05, 70));

        }

        [Test]
        public void FuelConsumptionlShouldntBeZeroOrNegative()
        {

            Assert.Throws<ArgumentException>(() => new Car("Opel", "Astra", 0, 70));
            Assert.Throws<ArgumentException>(() => new Car("Opel", "Astra", -2, 70));

        }


        [Test]
        public void FuelCapacitylShouldntBeZeroOrNegative()
        {

            Assert.Throws<ArgumentException>(() => new Car("Opel", "Astra", 0.05, -10));
            Assert.Throws<ArgumentException>(() => new Car("Opel", "Astra", 0.05, 0));

        }

        [Test]
        public void FuelAmountShouldntBeZeroOrNegative()
        {

            Car car = new Car("Opel", "Astra", 0.05, 70);
            Car car1 = new Car("Opel", "Astra", 0.05, 70);

            Assert.Throws<ArgumentException>(() => car.Refuel(0));
            Assert.Throws<ArgumentException>(() => car1.Refuel(-1));



        }


        [Test]
        public void FuelShoudIncreaceAndStopAtCapacity()
        {

            Car car = new Car("Opel", "Astra", 0.05, 20);
            Car car1 = new Car("Opel", "Astra", 0.05, 30);
            car.Refuel(18);
            car1.Refuel(55);

            Assert.AreEqual(18, car.FuelAmount);
            Assert.AreEqual(30, car1.FuelAmount);



        }

        [Test]
        public void FuelShoudntBeEnoughforTheDrive()
        {

            Car car = new Car("Opel", "Astra", 5, 20);
            car.Refuel(18);

            Assert.Throws<InvalidOperationException>(() => car.Drive(10000));



        }


        [Test]
        public void FuelShoudBeEnoughforTheDrive()
        {

            Car car1 = new Car("Opel", "Astra", 0.05, 30);
            car1.Refuel(55);
            car1.Drive(50);

            Assert.AreEqual(29.975, car1.FuelAmount);



        }

    }
}