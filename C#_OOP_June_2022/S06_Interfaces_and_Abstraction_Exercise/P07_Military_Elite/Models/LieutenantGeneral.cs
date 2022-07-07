namespace MilitaryElite.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LieutenantGeneral : Soldier, ILieutenantGeneral, IPrivate
    {
        private decimal salary;
        private readonly List<Private> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
            privates = new List<Private>();
        }

        public decimal Salary
        {
            get => salary;
            private set
            {
                salary = value;
            }
        }
        public IReadOnlyCollection<Private> Privates
        {
            get => privates;
        }

        public void AddPrivateId(Private pr)
        {
            privates.Add(pr);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString() + $"Salary: {Salary:F2}");
            sb.AppendLine("Privates:");
            foreach (var pr in Privates)
            {
                sb.AppendLine($"  {pr}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
