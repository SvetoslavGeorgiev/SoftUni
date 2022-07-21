namespace Formula1.Repositories
{
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models 
        {
            get { return (IReadOnlyCollection<IFormulaOneCar>)models; }
        }

        public void Add(IFormulaOneCar car)
        {
            if (models.Any(x => x.Model == car.Model))
            {
                throw new InvalidOperationException($"Formula one car {car.Model} is already created.");
            }
            models.Add(car);
        }

        public IFormulaOneCar FindByName(string name)
        {
            var car = models.FirstOrDefault(x => x.Model == name);
            if (car == null)
            {
                throw new NullReferenceException($"Car {name} does not exist.");
            }
            return car;
        }

        public bool Remove(IFormulaOneCar car)
        {
            var carToRemove = models.FirstOrDefault(x => x.Model == car.Model);

            if (carToRemove != null)
            {
                models.Remove(car);
                return true;
            }
            return false;
        }
    }
}
