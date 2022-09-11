namespace SoftUni
{
    using Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {

            using SoftUniContext dbContext = new SoftUniContext();

            string result = GetEmployee147(dbContext);

            Console.WriteLine(result);


        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                         .OrderBy(ep => ep.Project.Name)
                         .Select(ep => new
                         {
                             ProjectName = ep.Project.Name,
                         })
                         .ToArray()
                })
                .First();
            
            output.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
            foreach (var project in employee147.Projects)
            {
                output.AppendLine($"{project.ProjectName}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
