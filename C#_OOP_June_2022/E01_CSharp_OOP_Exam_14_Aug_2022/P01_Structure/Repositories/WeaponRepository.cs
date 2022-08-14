namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => throw new NotImplementedException();

        public void AddItem(IWeapon model)
        {
            throw new NotImplementedException();
        }

        public IWeapon FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
