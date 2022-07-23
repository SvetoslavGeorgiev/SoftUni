﻿namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets = new List<string>();


        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
        }


        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        public ICaptain Captain 
        {
            get => captain;
            set
            {
                captain = value ?? throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
            }

        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber
        {
            get => mainWeaponCaliber;
            protected set
            {
                mainWeaponCaliber = value;
            }
        }

        public double Speed
        {
            get => speed;
            protected set
            {
                speed = value;
            }
        }

        public ICollection<string> Targets
        {
            get => targets;
            private set => targets = value;
        }

        public void Attack(IVessel target)
        {
            
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            if (target.ArmorThickness - MainWeaponCaliber < 0)
            {
                target.ArmorThickness = 0.00;
                
            }
            else
            {
                target.ArmorThickness -= MainWeaponCaliber;
            }
            if (!Targets.Contains(target.Name))
            {
                Targets.Add(target.Name);
            }
            

            Captain.IncreaseCombatExperience();
            target.Captain.IncreaseCombatExperience();

        }

        public virtual void RepairVessel()
        {
            

            if (this.GetType().Name == typeof(Submarine).Name)
            {
                ArmorThickness = 200.00;
            }
            else
            {
                ArmorThickness = 300.00;
            }
            
        }

        public override string ToString()
        {
            var sb  = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.AppendLine(Targets.Count == 0 ? " *Targets: None" : $" *Targets: {string.Join(", ", Targets)}");


            return sb.ToString().TrimEnd();
        }
    }
}
