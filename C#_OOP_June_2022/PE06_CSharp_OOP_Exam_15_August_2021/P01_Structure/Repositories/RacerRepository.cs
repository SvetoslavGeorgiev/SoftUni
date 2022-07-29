namespace CarRacing.Repositories
{
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RacerRepository : IRepository<IRacer>
    {
        private readonly ICollection<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => throw new NotImplementedException();

        public void Add(IRacer model)
        {
            throw new NotImplementedException();
        }

        public IRacer FindBy(string property)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IRacer model)
        {
            throw new NotImplementedException();
        }
    }
}
