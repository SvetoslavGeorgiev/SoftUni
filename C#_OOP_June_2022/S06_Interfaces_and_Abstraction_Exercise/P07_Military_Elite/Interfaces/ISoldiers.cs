namespace MilitaryElite.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;
    public interface ISoldiers
    {
        public List<Soldier> ListOfSoldiers { get; set; }
    }
}
