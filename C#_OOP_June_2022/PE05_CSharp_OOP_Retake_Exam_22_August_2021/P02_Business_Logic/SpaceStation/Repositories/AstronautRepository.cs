namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> models;

        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => (IReadOnlyCollection<IAstronaut>)models;

        public void Add(IAstronaut model)
        {
            models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
            return models.Remove(model);
        }
    }
}
