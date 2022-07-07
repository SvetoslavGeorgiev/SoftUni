namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    public class SpecialisedSoldier : Soldier, IPrivate
    {
        private string corp;
        private decimal salary;
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corp) : base(id, firstName, lastName)
        {
            Salary = salary;
            Corp = corp;
        }


        public string Corp
        {
            get => corp;
            private set 
            { 
                corp = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            private set
            {
                salary = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Salary: {Salary:F2}" + Environment.NewLine + $"Corps: {Corp}";
        }
    }
}
