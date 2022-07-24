namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;

    public class GymsTests
    {

        [Test]
        public void ConstructorShouldGiveMeCorectResullt()
        {
            var gym = new Gym("Olimpyc", 3);
            var gym1 = new Gym("Olimpyc1", 0);

            Assert.IsNotNull(gym);
            Assert.AreEqual(0, gym.Count);
            Assert.AreEqual("Olimpyc", gym.Name);
            Assert.AreEqual(3, gym.Capacity);
            Assert.AreEqual(0, gym1.Count);
            Assert.AreEqual(0, gym1.Capacity);
        }
        [Test]
        public void ConstructorShouldThrowArgumentExceptionIfCapacityIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Olimpyc", -3));
        }

        [Test]
        public void NameShouldThrowArgumentNullExceptionIfNameIsNullorEmpty()
        {

            Assert.Throws<ArgumentNullException>(() => new Gym(String.Empty, 3));
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 3));
        }

        [Test]
        public void AddAthleteShouldGiveMeCorectResulltWhenAddidngCorrectAthlete()
        {
            var gym = new Gym("Olimpyc", 3);

            var athlete = new Athlete("Pesho");

            gym.AddAthlete(athlete);

            Assert.IsNotNull(athlete);
            Assert.AreEqual(1, gym.Count);
            Assert.AreEqual(3, gym.Capacity);
        }


        [Test]
        public void RemoveAthleteShouldThrowsInvalidOperationExceptionWhenRmovinNotExistingAthlete()
        {
            var gym = new Gym("Olimpyc", 3);

            var athlete = new Athlete("Pesho");

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Gosho"));

        }

        [Test]
        public void AddAthleteShouldThrowsInvalidOperationExceptionWhenAddidngAthleteIsOverTheCapacit()
        {
            var gym = new Gym("Olimpyc", 1);

            var athlete = new Athlete("Pesho");

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Gosho")));
        }


        [Test]
        public void RemoveAthleteShouldReturnCorrectCountAfterRemovingAthlete()
        {
            var gym = new Gym("Olimpyc", 3);

            var athlete = new Athlete("Pesho");
            var athlete1 = new Athlete("Gosho");
            var athlete2 = new Athlete("Sasho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);

            Assert.AreEqual(3, gym.Count);

            gym.RemoveAthlete("Gosho");


            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void InjureAthleteShouldThrowsInvalidOperationExceptionWhenNotExistingAthlete()
        {
            var gym = new Gym("Olimpyc", 3);

            var athlete = new Athlete("Pesho");

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Gosho"));

        }


        [Test]
        public void InjureAthleteShouldReturnAthleteInjured()
        {
            var gym = new Gym("Olimpyc", 3);

            var athlete = new Athlete("Pesho");

            gym.AddAthlete(athlete);

            var injuredAthlete = gym.InjureAthlete("Pesho");

            Assert.IsNotNull(injuredAthlete);

            Assert.AreEqual(true, injuredAthlete.IsInjured);

        }


        [Test]
        public void ReportShouldReturnCorrectMessage()
        {
            var gym = new Gym("Olimpyc", 3);

            var athlete = new Athlete("Pesho");
            var athlete1 = new Athlete("Gosho");
            var athlete2 = new Athlete("Sasho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);

            var expextedMessage = "Active athletes at Olimpyc: Pesho, Gosho, Sasho";

            Assert.AreEqual(expextedMessage, gym.Report());

            athlete1.IsInjured = true;

            Assert.AreEqual("Active athletes at Olimpyc: Pesho, Sasho", gym.Report());

        }


    }
}
