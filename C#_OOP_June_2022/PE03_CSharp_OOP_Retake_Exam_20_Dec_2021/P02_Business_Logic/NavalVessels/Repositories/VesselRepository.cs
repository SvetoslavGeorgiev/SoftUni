namespace NavalVessels.Repositories
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> models;

        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models 
        {
            get { return (IReadOnlyCollection<IVessel>)models; }
        }

        public void Add(IVessel model)
        {
            
            models.Add(model);
        }

        public IVessel FindByName(string name)
        {
            var vessel = models.FirstOrDefault(x => x.Name == name);
            
            return vessel;
        }

        public bool Remove(IVessel model)
        {
            //if has a problem to check
            return models.Remove(model);
        }
    }
}
