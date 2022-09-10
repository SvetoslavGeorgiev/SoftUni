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

            string result = AddNewAddressToEmployee(dbContext);

            Console.WriteLine(result);

        }



        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Add(newAddress);

            var nakov = context
                .Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            nakov.Address = newAddress;

            context.SaveChanges();

            var addressText = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToArray();


            foreach (var item in addressText)
            {
                output.AppendLine(item);
            }


            return output.ToString().TrimEnd();
        }
    }
}
