namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    public class Private : Soldier, IPrivate
    {
        private decimal salary;
        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }


        public decimal Salary
        {
            get { return salary; }
            private set 
            { 
                salary = value; 
            }
        }

    }
}
