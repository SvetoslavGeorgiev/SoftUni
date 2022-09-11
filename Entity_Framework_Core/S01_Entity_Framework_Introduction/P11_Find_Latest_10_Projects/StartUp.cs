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

            string result = GetLatestProjects(dbContext);

            Console.WriteLine(result);


        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var Last10Projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                })
                .Take(10)
                .ToList();

            foreach (var project in Last10Projects.OrderBy(x => x.Name))
            {
                output.AppendLine($"{project.Name}"
                    + Environment.NewLine
                    + $"{project.Description}"
                    + Environment.NewLine
                    + $"{project.StartDate}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
