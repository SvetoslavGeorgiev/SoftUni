namespace PlanetWars.Repositories
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly ICollection<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => throw new NotImplementedException();

        public void AddItem(IMilitaryUnit model)
        {
            throw new NotImplementedException();
        }

        public IMilitaryUnit FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
