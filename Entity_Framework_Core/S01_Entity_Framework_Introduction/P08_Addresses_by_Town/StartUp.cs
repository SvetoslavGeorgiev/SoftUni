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

            string result = GetAddressesByTown(dbContext);

            Console.WriteLine(result);

        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var allAddresses = context
                .Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    a.AddressText,
                    a.Town.Name,
                    EmployeesOnTheAddress = a.Employees.Count
                })
                .Take(10)
                .ToList();


            foreach (var address in allAddresses)
            {
                output.AppendLine($"{address.AddressText}, {address.Name} - {address.EmployeesOnTheAddress} employees");
            }


            return output.ToString().TrimEnd();
        }

    }
}
