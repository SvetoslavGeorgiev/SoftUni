namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private readonly ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            FullName = fullName;
            CombatExperience = 0;
            vessels = new List<IVessel>();
        }
        public string FullName
        {
            get => fullName;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value; 
            }
        }

        public int CombatExperience
        {
            get => combatExperience;
            private set
            {
                if (value % 10 == 0)
                {
                    combatExperience = value;
                }
                
            }
        }

        public ICollection<IVessel> Vessels => vessels;


        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            if (Vessels.All(x => x.Name != vessel.Name))
            {
                Vessels.Add(vessel);
            }
            
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            if (Vessels.Count == 0)
            {
                return $"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.";
            }

            var sb = new StringBuilder();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            foreach (var vs in Vessels)
            {
                sb.AppendLine(vs.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
