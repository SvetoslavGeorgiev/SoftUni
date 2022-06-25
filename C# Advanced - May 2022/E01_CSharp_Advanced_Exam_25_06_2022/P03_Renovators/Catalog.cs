using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public List<Renovator> Renovators { get; set; }

        public int Count => Renovators.Count;
        public string AddRenovator(Renovator renovator)
        {
            if (NeededRenovators > Renovators.Count)
            {
                if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
                {
                    return "Invalid renovator's information.";
                }
                else if (renovator.Rate > 350)
                {
                    return "Invalid renovator's rate.";
                }
                else
                {
                    Renovators.Add(renovator);
                    return $"Successfully added {renovator.Name} to the catalog.";
                }
            }
            else
            {
                return "Renovators are no more needed.";
            }

        }

        public bool RemoveRenovator(string name)
        {
            var renovator = Renovators.FirstOrDefault(x => x.Name == name);

            if (renovator != null)
            {
                Renovators.Remove(renovator);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;

            count = Renovators.FindAll(x => x.Type == type).Count();

            Renovators.RemoveAll(x => x.Type == type);
            return count;
        }


        public Renovator HireRenovator(string name)
        {
            if (Renovators.Find(x => x.Name == name) == null)
            {
                return null;
            }
            else
            {
                var renovator = Renovators.Find(x => x.Name == name);
                renovator.Hired = true;
                return renovator;
            }
        }

        public List<Renovator> PayRenovators(int days)
        {
            return Renovators.FindAll(x => x.Days >= days);
        }

        public string Report()
        {
            var filtered = Renovators.Where(x => x.Hired == false).ToList();

            var sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var item in filtered)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
