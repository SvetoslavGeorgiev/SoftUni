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

            string result = DeleteProjectById(dbContext);

            Console.WriteLine(result);

        }


        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var projectsToDelete = context
                .Projects
                .Find(2);

            var refferedProjects = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == projectsToDelete.ProjectId)
                .ToList();

            context.EmployeesProjects.RemoveRange(refferedProjects);
            context.Projects.Remove(projectsToDelete);

            context.SaveChanges();

            var projects = context
                .Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();


            foreach (var project in projects)
            {
                output.AppendLine(project);
            }


            return output.ToString().TrimEnd();
        }
    }
}
