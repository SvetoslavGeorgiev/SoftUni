using WildFarm.Contracts;

namespace WildFarm.Models
{
    public abstract class Mammal : Animal, IMammal
    {
        private string livingRegion;
        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get => livingRegion;
            protected set
            {
                livingRegion = value;
            }
        }
    }
}
