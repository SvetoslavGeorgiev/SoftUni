namespace Heroes.Repositories
{
    using Heroes.Models.Heroes;
    using Heroes.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using Heroes.Models.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly IList<IHero> models;
        public HeroRepository() : base()
        {
            models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models
        {
            get { return (IReadOnlyCollection<IHero>)models; }
        }
        public void Add(IHero model)
        {
            if (models.All(x => x.Name != model.Name))
            {
                models.Add(model);
            }
        }

        public IHero FindByName(string name)
        {
            var hero = models.FirstOrDefault(x => x.Name == name);
            if (hero == null)
            {
                return null;
            }
            return hero;
        }

        public bool Remove(IHero model)
        {
            var heroToRemove = models.FirstOrDefault(x => x.Name == model.Name);

            if (heroToRemove != null)
            {
                var index = models.IndexOf(model);

                models.RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}
