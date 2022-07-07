namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Commando : SpecialisedSoldier
    {
        private readonly List<Mission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corp) : base(id, firstName, lastName, salary, corp)
        {
            missions = new List<Mission>();
        }

        public IReadOnlyCollection<Mission> Missions
        {
            get { return missions; }
        }

        public void AddMission(Mission mission)
        {
            if (mission.MissionState == "inProgress")
            {
                missions.Add(mission);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine(mission.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
