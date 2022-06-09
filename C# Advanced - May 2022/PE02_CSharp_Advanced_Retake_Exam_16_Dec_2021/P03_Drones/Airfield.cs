using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        
        public Airfield(string name, int capacity, double landingStrip)
        {
            Drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public int Count { get { return Drones.Count; } }

        private List<Drone> drones;


        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrWhiteSpace(drone.Name) || string.IsNullOrWhiteSpace(drone.Brand) || drone.Range > 15 || drone.Range < 5)
            {
                return "Invalid drone.";
            }
            else if (Drones.Count < Capacity)
            {
                Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
            else
            {
                return "Airfield is full.";
            }

        }

        public bool RemoveDrone(string name)
        {
            if (Drones.Find(x => x.Name == name) == null)
            {
                return false;
            }
            else
            {
                Drones.Remove(Drones.Find(x => x.Name == name));
                return true;
            }
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = Drones.Count;

            Drones.RemoveAll(drone => drone.Brand == brand);

            if (count == Drones.Count)
            {
                return 0;
            }
            else
            {
                return count - Drones.Count;
            }
        }

        public Drone FlyDrone(string name)
        {

            

            if (Drones.Find(x => x.Name == name) == null)
            {
                return null;
            }
            else
            {
                var drone = Drones.Find(x => x.Name == name);
                drone.Fly();
                return drone;
            }
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = new List<Drone>();

            drones = Drones.FindAll(x => x.Range >= range);

            foreach (var drone in drones)
            {
                drone.Fly();
            }

            return drones;
        }

        public string Report()
        {
            var av = Drones.Where(x => x.Available == true).ToList();

            var sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var item in av)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
