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

            string result = GetDepartmentsWithMoreThan5Employees(dbContext);

            Console.WriteLine(result);

        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var departmentsWithMoreThen5Employees = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                         .OrderBy(e => e.FirstName)
                         .ThenBy(e => e.LastName)
                         .Select(e => new
                         {
                             e.FirstName,
                             e.LastName,
                             e.JobTitle
                         })
                         .ToArray()
                })
                .ToArray();


            foreach (var departmet in departmentsWithMoreThen5Employees)
            {
                output.AppendLine($"{departmet.Name} - {departmet.ManagerFirstName} {departmet.ManagerLastName}");
                foreach (var employee in departmet.Employees)
                {
                    output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}
