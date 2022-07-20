namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horcepower;
        private double engineDisplacement;
        public FormulaOneCar(string model, int horcepower, double engineDisplacement)
        {
            this.model = model;
            this.horcepower = horcepower;
            this.engineDisplacement = engineDisplacement;
        }

        public string Model => throw new NotImplementedException();

        public int Horsepower => throw new NotImplementedException();

        public double EngineDisplacement => throw new NotImplementedException();

        public double RaceScoreCalculator(int laps)
        {
            throw new NotImplementedException();
        }
    }
}
