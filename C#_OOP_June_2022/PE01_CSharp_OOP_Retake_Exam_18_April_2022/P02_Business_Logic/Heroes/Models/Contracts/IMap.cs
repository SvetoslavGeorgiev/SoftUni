using System.Collections.Generic;

namespace Heroes.Models.Contracts
{
    public interface IMap
    {
        string Fight(ICollection<IHero> players);
    }
}