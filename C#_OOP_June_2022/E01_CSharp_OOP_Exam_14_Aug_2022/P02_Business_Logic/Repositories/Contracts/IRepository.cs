using System.Collections.Generic;

namespace PlanetWars.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void AddItem(T model);

        T FindByName(string name);

        bool RemoveItem(string name);
    }
}
