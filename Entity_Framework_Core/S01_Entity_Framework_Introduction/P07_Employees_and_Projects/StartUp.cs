namespace SoftUni
{
    using System;
    using Data;
    using Models;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext dbContext = new SoftUniContext();

            string result = GetEmployeesInPeriod(dbContext);

            Console.WriteLine(result);


        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var filteredEmployees = context
                .Employees
                .Where(e => e.EmployeesProjects
                              .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    AllProject = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ep.Project.Name,
                            ep.Project.StartDate,
                            ep.Project.EndDate
                        })
                })
                .ToList();

            

            foreach (var em in filteredEmployees)
            {
                output.AppendLine($"{em.FirstName} {em.LastName} - Manager: {em.ManagerFirstName} {em.ManagerLastName}");

                foreach (var project in em.AllProject)
                {
                    var endDate = project.EndDate.HasValue ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";

                    output.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {endDate}");
                }
            }


            return output.ToString().TrimEnd();
        }
    }
}
