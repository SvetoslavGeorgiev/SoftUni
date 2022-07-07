namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Engineer : SpecialisedSoldier
    {
        private readonly List<Repair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corp) : base(id, firstName, lastName, salary, corp)
        {
            repairs = new List<Repair>();
        }

        public IReadOnlyCollection<Repair> Repairs
        {
            get { return repairs; }
        }

        public void AddRepair(Repair repair)
        {
            repairs.Add(repair);
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine(repair.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
