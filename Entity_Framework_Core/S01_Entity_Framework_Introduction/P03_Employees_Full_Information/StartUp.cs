namespace SoftUni
{
    using Data;
    using Models;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {

            using SoftUniContext dbContext = new SoftUniContext();

            string result = GetEmployeesFullInformation(dbContext);

            System.Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            Employee[] allEmployees = context.Employees.OrderBy(e => e.EmployeeId).ToArray();

            foreach (var e in allEmployees)
            {
                output
                    .AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
