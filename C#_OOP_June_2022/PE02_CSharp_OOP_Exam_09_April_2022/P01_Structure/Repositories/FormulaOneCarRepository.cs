namespace Formula1.Repositories
{
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        public IReadOnlyCollection<IFormulaOneCar> Models => throw new NotImplementedException();

        public void Add(IFormulaOneCar model)
        {
            throw new NotImplementedException();
        }

        public IFormulaOneCar FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IFormulaOneCar model)
        {
            throw new NotImplementedException();
        }
    }
}
