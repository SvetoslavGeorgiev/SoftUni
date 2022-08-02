namespace Formula1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Ferrari : FormulaOneCar
    {
        public Ferrari(string model, int horsepower, double engineDisplacement) : base(model, horsepower, engineDisplacement)
        {
        }
    }
}
