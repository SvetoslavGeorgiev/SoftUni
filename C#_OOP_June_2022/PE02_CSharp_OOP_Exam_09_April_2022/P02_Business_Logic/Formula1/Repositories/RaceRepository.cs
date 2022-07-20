namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models
        {
            get { return (IReadOnlyCollection<IRace>)models; }
        }

        public void Add(IRace race)
        {
            if (models.Any(x => x.RaceName == race.RaceName))
            {
                throw new InvalidOperationException($"Race {race.RaceName} is already created.");
            }
            models.Add(race);
        }

        public IRace FindByName(string name)
        {
            var race = models.FirstOrDefault(x => x.RaceName == name);
            if (race == null)
            {
                throw new NullReferenceException($"Race {name} does not exist.");
            }
            return race;
        }

        public bool Remove(IRace race)
        {
            var raceToRemove = models.FirstOrDefault(x => x.RaceName == race.RaceName);

            if (raceToRemove != null)
            {
                models.Remove(raceToRemove);
                return true;
            }
            return false;
        }
    }
}
