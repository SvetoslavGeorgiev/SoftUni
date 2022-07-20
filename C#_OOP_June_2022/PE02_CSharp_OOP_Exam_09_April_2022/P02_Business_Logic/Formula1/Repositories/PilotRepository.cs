namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PilotRepository : IRepository<IPilot>
    {

        private readonly ICollection<IPilot> models;

        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models
        {
            get { return (IReadOnlyCollection<IPilot>)models; }
        }

        public void Add(IPilot pilot)
        {
            if (models.Any(x => x.FullName == pilot.FullName))
            {
                throw new InvalidOperationException($"Pilot {pilot.FullName} is already created.");
            }
            models.Add(pilot);
        }

        public IPilot FindByName(string name)
        {
            var pilot = models.FirstOrDefault(x => x.FullName == name);
            if (pilot == null)
            {
                return null;
            }
            return pilot;
        }

        public bool Remove(IPilot pilot)
        {
            var pilotToRemove = models.FirstOrDefault(x => x.FullName == pilot.FullName);

            if (pilotToRemove != null)
            {
                models.Remove(pilotToRemove);
                return true;
            }
            return false;
        }
    }
}
