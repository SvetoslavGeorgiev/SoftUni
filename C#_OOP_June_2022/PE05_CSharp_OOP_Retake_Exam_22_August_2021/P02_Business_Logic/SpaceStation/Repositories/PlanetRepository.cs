namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PlanetRepository : IRepository<IPlanet>
    {

        private readonly ICollection<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)models;

        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return models.Remove(model);
        }
    }
}
