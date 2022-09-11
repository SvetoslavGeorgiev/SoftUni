namespace SoftUni.Models
{
    using System;
    using System.Collections.Generic;
    public class Project
    {
        public Project()
        {
            EmployeesProjects = new HashSet<EmployeeProject>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }

        public override string ToString()
        {
            //--Half-Finger Gloves - 6/1/2002 12:00:00 AM - 6/1/2003 12:00:00 AM

            var endDate = EndDate.HasValue ? EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";

            return $"--{Name} - {StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {endDate}";
        }
    }
}
