namespace WildFarm.Contracts
{
    using System.Collections.Generic;
    using WildFarm.Models;

    internal interface IWildFarm
    {
        IReadOnlyCollection<Animal> Animals { get; }

        string PrintAnimals();
        void AddAnimal(Animal animal);
    }
}
