namespace NavalVessels.Models.Contracts
{
    using System.Collections.Generic;
    public interface ICaptain
    {
        string FullName { get; }
        public int CombatExperience { get; }
        public ICollection<IVessel> Vessels { get; }
        void AddVessel(IVessel vessel);
        void IncreaseCombatExperience();
        string Report();
    }
}
