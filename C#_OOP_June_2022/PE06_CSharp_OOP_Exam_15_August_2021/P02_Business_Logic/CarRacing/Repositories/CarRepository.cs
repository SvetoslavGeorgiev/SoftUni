namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>)models;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            models.Add(model);
        }

        public ICar FindBy(string property)
        {
            return Models.FirstOrDefault(x => x.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }
    }
}
