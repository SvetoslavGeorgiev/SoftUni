using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {

        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Ski ski)
        {
            if (Capacity > data.Count)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var resilt = data.Find(x => x.Manufacturer == manufacturer && x.Model == model);
            if (resilt == null)
            {
                return false;
            }
            else
            {
                data.Remove(resilt);
                return true;
            }
        }

        public Ski GetNewestSki()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            var ski = data.Find(x => x.Manufacturer == manufacturer && x.Model.Equals(model));

            if (ski == null)
            {
                return null;
            }
            return ski;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
