namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThicknes;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets = new List<string>();
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThicknes)
        {
            this.name = name;
            this.mainWeaponCaliber = mainWeaponCaliber;
            this.speed = speed;
            this.armorThicknes = armorThicknes;
        }


        public string Name => throw new NotImplementedException();

        public ICaptain Captain { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double ArmorThickness { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double MainWeaponCaliber => throw new NotImplementedException();

        public double Speed => throw new NotImplementedException();

        public ICollection<string> Targets => throw new NotImplementedException();

        public void Attack(IVessel target)
        {
            throw new NotImplementedException();
        }

        public void RepairVessel()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
