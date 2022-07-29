namespace CarRacing.Repositories
{
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RacerRepository : IRepository<IRacer>
    {
        private readonly ICollection<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => (IReadOnlyCollection<IRacer>)models;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return Models.FirstOrDefault(x => x.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return models.Remove(model);
        }
    }
}
