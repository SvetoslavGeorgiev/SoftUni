namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => throw new NotImplementedException();

        public void Add(ICar model)
        {
            throw new NotImplementedException();
        }

        public ICar FindBy(string property)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ICar model)
        {
            throw new NotImplementedException();
        }
    }
}
