namespace NavalVessels.Models.Contracts
{
    using System.Collections.Generic;
    public interface IVessel
    {
        string Name { get; }
        ICaptain Captain { get; set; }
        double ArmorThickness { get; set; }
        double MainWeaponCaliber { get; }
        double Speed { get; }
        ICollection<string> Targets { get; }
        void Attack(IVessel target);
        void RepairVessel();
        string ToString();
    }
}
