namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private readonly ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
            pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => raceName;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }

                raceName = value; 
            }
        }

        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }

                numberOfLaps = value;
            }
        }


        public bool TookPlace { get; set; }


        public ICollection<IPilot> Pilots
        { 
            get { return pilots; }
        }


        public void AddPilot(IPilot pilot)
        {
            //if (pilot == null)
            //{
            //    throw new NullReferenceException($"Null pilot can not be added to a race.");
            //}
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            sb.AppendLine(TookPlace == true ? $"Took place: Yes" : $"Took place: No");


            return sb.ToString().Trim();

        }
    }
}
