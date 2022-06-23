using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>(capacity);
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public List<Car> Participants { get; set; }

        

        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (Participants.Count < Capacity && Participants.FirstOrDefault(x => x.LicensePlate == car.LicensePlate) == null && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }

        
        public bool Remove(string licensePlate)
        {
            var result = false;

            var carToRemove = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);

            if (carToRemove != null)
            {
                result = true;
                Participants.Remove(carToRemove);
            }
            return result;
        }

        public Car FindParticipant(string licensePlate)
        {

            return Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);


        }

        public Car GetMostPowerfulCar()
        {
            return Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }


        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var participant in Participants)
            {
                sb.AppendLine(participant.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
