namespace SoftUni
{
    using Data;
    using Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {

            using SoftUniContext dbContext = new SoftUniContext();

            string result = GetEmployeesWithSalaryOver50000(dbContext);

            System.Console.WriteLine(result);

        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var allEmployees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var e in allEmployees)
            {
                output
                    .AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
