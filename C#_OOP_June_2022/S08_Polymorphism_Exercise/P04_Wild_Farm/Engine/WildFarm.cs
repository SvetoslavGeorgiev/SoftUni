namespace WildFarm.Engine
{
    
    using System.Collections;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Contracts;
    using Models;
    using System.Text;

    public class WildFarm : IWildFarm
    {
        private ICollection<Animal> animals;

        public WildFarm()
        {
            animals = new List<Animal>();
        }

        public IReadOnlyCollection<Animal> Animals
        {
            get => (IReadOnlyCollection<Animal>)animals;
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public string PrintAnimals()
        {
            var sb = new StringBuilder();
            foreach (var animal in animals)
            {
                sb.AppendLine(animal.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
