namespace Formula1.Models.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Williams : FormulaOneCar
    {
        public Williams(string model, int horcepower, double engineDisplacement) : base(model, horcepower, engineDisplacement)
        {
        }
    }
}
