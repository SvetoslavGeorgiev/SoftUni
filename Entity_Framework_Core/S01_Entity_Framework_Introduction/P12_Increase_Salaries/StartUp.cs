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

            string result = IncreaseSalaries(dbContext);

            Console.WriteLine(result);

        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employeesForSalaryIcrease = context
                .Employees
                .Where(employee => employee.Department.Name == "Engineering" ||
                                   employee.Department.Name == "Tool Design" ||
                                   employee.Department.Name == "Marketing" ||
                                   employee.Department.Name == "Information Services")
                .OrderBy(employee => employee.FirstName)
                .ThenBy(employee => employee.LastName)
                .ToList();

            foreach (var em in employeesForSalaryIcrease)
            {

                em.Salary += em.Salary * 0.12m;

            }

            context.SaveChanges();


            foreach (var em in employeesForSalaryIcrease)
            {
                output.AppendLine($"{em.FirstName} {em.LastName} (${em.Salary:F2})");

            }

            

            return output.ToString().TrimEnd();
        }
    }
}
