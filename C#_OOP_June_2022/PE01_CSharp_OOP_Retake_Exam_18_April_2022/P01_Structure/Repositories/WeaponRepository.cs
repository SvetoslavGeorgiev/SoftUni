namespace Heroes.Repositories
{
    using Heroes.Models.Contracts;
    using Heroes.Models.Weapons;
    using Heroes.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly IList<IWeapon> models;

        public WeaponRepository() : base()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models 
        {
            get { return (IReadOnlyCollection<IWeapon>)models; }
        }

        public void Add(IWeapon model)
        {
            if (models.All(x => x.Name != model.Name))
            {
                models.Add(model);
            }
        }

        public IWeapon FindByName(string name)
        {
            var weapon = models.FirstOrDefault(x => x.Name == name);
            if (weapon == null)
            {
                return null;
            }
            return weapon;
        }

        public bool Remove(IWeapon model)
        {
            var weaponToRemove = models.FirstOrDefault(x => x.Name == model.Name);

            if (weaponToRemove != null)
            {
                var index = models.IndexOf(model);

                models.RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}
