namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Models.Bags.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            bag = new Backpack();
        }

        public string Name
        {
            get => name;
            private set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                name = value; 
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                oxygen = value;
            }
        }

        public virtual bool CanBreath => Oxygen >= 10.00; // should be double in case oxygen is 9.99 or 10.01 

        public IBag Bag => bag;

        public virtual void Breath()
        {
            if (Oxygen - 10 <= 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= 10.00;
            }
            
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Oxygen: {Oxygen}");
            sb.AppendLine(Bag.Items.Count == 0 ? $"Bag items: none" : $"Bag items: {string.Join(", ", bag.Items)}");

            return sb.ToString().Trim();
        }
    }
}
