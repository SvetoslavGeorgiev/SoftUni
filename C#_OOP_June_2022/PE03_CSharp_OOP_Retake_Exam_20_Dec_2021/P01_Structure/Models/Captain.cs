namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience = 0;
        private ICollection<IVessel> vessels = new List<IVessel>(); 

        public Captain(string fullName)
        {
            this.fullName = fullName;
        }
        public string FullName => throw new NotImplementedException();

        public int CombatExperience => throw new NotImplementedException();

        public ICollection<IVessel> Vessels => throw new NotImplementedException();

        public void AddVessel(IVessel vessel)
        {
            throw new NotImplementedException();
        }

        public void IncreaseCombatExperience()
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
