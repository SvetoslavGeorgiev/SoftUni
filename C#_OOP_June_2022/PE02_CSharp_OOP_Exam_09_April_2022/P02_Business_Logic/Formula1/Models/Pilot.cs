namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace;
        private IFormulaOneCar car;
        private int numberOfWin;

        public Pilot(string fullName)
        {
            FullName = fullName;
            CanRace = false;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }
                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                car = value;
            }
        }
        

        public int NumberOfWins
        {
            get => numberOfWin;
            private set
            {
                numberOfWin = value;
            }
        }


        public bool CanRace
        {
            get { return canRace; }
            private set
            {
                canRace = value;
            }
        }

        public void AddCar(IFormulaOneCar car)
        {
            if (Car != null)
            {
                throw new InvalidOperationException($"Pilot {FullName} does not exist or has a car.");
            }
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
