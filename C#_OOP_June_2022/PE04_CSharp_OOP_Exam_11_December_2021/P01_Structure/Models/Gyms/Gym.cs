namespace Gym.Models.Gyms
{
    using global::Gym.Models.Athletes.Contracts;
    using global::Gym.Models.Equipment.Contracts;
    using global::Gym.Models.Gyms.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private ICollection<IEquipment> equipment;
        private ICollection<IAthlete> athletes;
        private double equipmentWeight;

        public Gym(string name, int capacity)
        {
            this.name = name;
            this.capacity = capacity;
            equipment = new HashSet<IEquipment>();
            athletes = new HashSet<IAthlete>();
            equipmentWeight = equipment.Sum(x => x.Weight);
        }




        public string Name => throw new NotImplementedException();

        public int Capacity => throw new NotImplementedException();

        public double EquipmentWeight => throw new NotImplementedException();

        public ICollection<IEquipment> Equipment => throw new NotImplementedException();

        public ICollection<IAthlete> Athletes => throw new NotImplementedException();

        public void AddAthlete(IAthlete athlete)
        {
            throw new NotImplementedException();
        }

        public void AddEquipment(IEquipment equipment)
        {
            throw new NotImplementedException();
        }

        public void Exercise()
        {
            throw new NotImplementedException();
        }

        public string GymInfo()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAthlete(Athletes.Contracts.IAthlete athlete)
        {
            throw new NotImplementedException();
        }



    }
}
