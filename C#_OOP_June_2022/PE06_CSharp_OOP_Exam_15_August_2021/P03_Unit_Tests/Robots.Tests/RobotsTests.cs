namespace Robots.Test
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {

        [Test]
        public void ConstructorShouldreturnvalidData()
        {
            var robotManager = new RobotManager(0);

            Assert.AreEqual(0, robotManager.Count);
            Assert.AreEqual(0, robotManager.Capacity);

        }

        [Test]
        public void ConstructorShouldThrowsInvalidOperationExceptionIfCapacityIsNEgative()
        {
            
            Assert.Throws<ArgumentException>(() => new RobotManager(-2));

        }

        [Test]
        public void ConstructorRetyrnProperCapacity()
        {
            var robotManager = new RobotManager(44);

            Assert.AreEqual(44, robotManager.Capacity);
            

        }

        [Test]
        public void AddShouldThrowsInvalidOperationExceptionIfCapacityIsFull()
        {
            var robotManager = new RobotManager(2);

            var robot = new Robot("Ted", 55);
            var robot1 = new Robot("Pesho", 45);
            robotManager.Add(robot);
            robotManager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Gosho", 59)));

        }




        [Test]
        public void AddShouldThrowsInvalidOperationExceptionIfRobotExist()
        {
            var robotManager = new RobotManager(3);

            var robot = new Robot("Ted", 55);
            var robot1 = new Robot("Pesho", 45);
            robotManager.Add(robot);
            robotManager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Pesho", 59)));

        }

        [Test]
        public void RemoveShouldReducesTheCOuntIfRobotExist()
        {
            var robotManager = new RobotManager(2);

            var robot = new Robot("Ted", 55);
            var robot1 = new Robot("Pesho", 45);
            robotManager.Add(robot);

            robotManager.Add(robot1);

            Assert.AreEqual(2, robotManager.Count);

            robotManager.Remove("Pesho");

            Assert.AreEqual(1, robotManager.Count);



        }

        [Test]
        public void RemoveShouldThrowsInvalidOperationExceptionIfRobotNotExist()
        {
            var robotManager = new RobotManager(2);

            var robot = new Robot("Ted", 55);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Pesho"));

        }

        [Test]
        public void WorkShouldThrowsInvalidOperationExceptionIfBateryISLessThenNeededOne()
        {
            var robotManager = new RobotManager(2);

            var robot = new Robot("Ted", 55);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Ted", "DoWork", 56));

        }

        [Test]
        public void WorkShouldThrowsInvalidOperationExceptionIfRobotNotExist()
        {
            var robotManager = new RobotManager(2);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Pesho", "DoWork", 23));

        }

        [Test]
        public void ChargeShouldReturnWithFullCharge()
        {
            var robotManager = new RobotManager(2);

            var robot = new Robot("Ted", 100);

            robotManager.Add(robot);

            robotManager.Work("Ted", "DoWork", 66);

            Assert.AreEqual(34, robot.Battery);

            robotManager.Charge("Ted");

            Assert.AreEqual(100, robot.Battery);

            robotManager.Work("Ted", "DoWork", 100);

            Assert.AreEqual(0, robot.Battery);
        }

        [Test]
        public void ChargeShouldThrowsInvalidOperationExceptionIfRobotNotExist()
        {
            var robotManager = new RobotManager(2);

            var robot = new Robot("Ted", 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Pesho"));

        }

        [Test]
        public void ChargeShouldReturnMaxCarge()
        {
            var robotManager = new RobotManager(2);

            var robot = new Robot("Ted", 100);

            robotManager.Add(robot);

            robotManager.Work("Ted", "DoWork", 66);

            robotManager.Charge("Ted");

            Assert.AreEqual(100, robot.MaximumBattery);
            Assert.AreEqual(100, robot.Battery);


        }


    }

}
