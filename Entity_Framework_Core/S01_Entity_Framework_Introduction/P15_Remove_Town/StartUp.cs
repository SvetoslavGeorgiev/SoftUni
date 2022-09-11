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

            string result = RemoveTown(dbContext);

            Console.WriteLine(result);


        }

        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var townToDelete = context
                .Towns
                .Where(t => t.Name == "Seattle")
                .FirstOrDefault();

            var refferedAddresses = context
                .Addresses
                .Where(a => a.TownId == townToDelete.TownId)
                .ToList();

            foreach (var e in context.Employees)
            {
                if (refferedAddresses.Any(x => x.AddressId == e.AddressId))
                {
                    e.AddressId = null;
                }
            }

            var numberOfAddressesDeleted = refferedAddresses.Count;
            

            context.Addresses.RemoveRange(refferedAddresses);
            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            return $"{numberOfAddressesDeleted} addresses in Seattle were deleted";
        }
    }
}
