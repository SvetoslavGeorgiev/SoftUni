using WildFarm.Contracts;

namespace WildFarm.Models
{
    public abstract class Feline : Mammal, IFeline
    {
        private string breed;
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed
        {
            get => breed;
            protected set 
            {
                breed = value; 
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
