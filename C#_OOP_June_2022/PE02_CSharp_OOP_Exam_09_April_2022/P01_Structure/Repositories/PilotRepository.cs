namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PilotRepository : IRepository<IPilot>
    {
        public IReadOnlyCollection<IPilot> Models => throw new NotImplementedException();

        public void Add(IPilot model)
        {
            throw new NotImplementedException();
        }

        public IPilot FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IPilot model)
        {
            throw new NotImplementedException();
        }
    }
}
