namespace Robots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RobotManager
    {
        private List<Robot> robots;
        private int capacity;

        public RobotManager(int capacity)
        {
            this.robots = new List<Robot>();
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid capacity!");
                }

                this.capacity = value;
            }
        }

        public int Count => this.robots.Count;

        public void Add(Robot robot)
        {
            if (this.robots.Any(r => r.Name == robot.Name))
            {
                throw new InvalidOperationException($"There is already a robot with name {robot.Name}!");
            }
            else if (this.robots.Count == this.capacity)
            {
                throw new InvalidOperationException("Not enough capacity!");
            }


            this.robots.Add(robot);
        }

        public void Remove(string name)
        {
            Robot robotToRemove = this.robots.FirstOrDefault(r => r.Name == name);

            if (robotToRemove == null)
            {
                throw new InvalidOperationException($"Robot with the name {name} doesn't exist!");
            }

            this.robots.Remove(robotToRemove);
        }

        public void Work(string robotName, string job, int batteryUsage)
        {
            Robot robot = this.robots.FirstOrDefault(r => r.Name == robotName);

            if (robot == null)
            {
                throw new InvalidOperationException($"Robot with the name {robotName} doesn't exist!");
            }
            else if (robot.Battery < batteryUsage)
            {
                throw new InvalidOperationException($"{robot.Name} doesn't have enough battery!");
            }

            robot.Battery -= batteryUsage;
        }

        public void Charge(string robotName)
        {
            Robot robot = this.robots.FirstOrDefault(r => r.Name == robotName);

            if (robot == null)
            {
                throw new InvalidOperationException($"Robot with the name {robotName} doesn't exist!");
            }

            robot.Battery = robot.MaximumBattery;
        }
    }
}
