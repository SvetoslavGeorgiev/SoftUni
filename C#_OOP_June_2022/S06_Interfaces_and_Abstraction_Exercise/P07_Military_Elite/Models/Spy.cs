namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Spy : Soldier
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        private int codeNumber;

        public int CodeNumber
        {
            get => codeNumber;
            private set 
            { 
                codeNumber = value; 
            }
        }

        public override string ToString()
        {
            return base.ToString().TrimEnd() + Environment.NewLine + $"Code Number: {codeNumber}";
        }

    }
}
