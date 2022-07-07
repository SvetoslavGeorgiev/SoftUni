using MilitaryElite.Models;

namespace MilitaryElite.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    public class Soldiers : ISoldiers
    {

        public List<Soldier> ListOfSoldiers { get; set; } = new List<Soldier>();

        public void AddSoldier(Soldier soldier)
        {
            ListOfSoldiers.Add(soldier);
        }

    }
}
