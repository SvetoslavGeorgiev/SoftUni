using WildFarm.Engine;

namespace WildFarm.Models
{
    using System;
    using WildFarm.Models_Food;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != Constants.Meat)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
            Weight += food.Quantity * Constants.TigerWeightIncrease;
        }

        public override string ProducingSound()
        {
            return "ROAR!!!";
        }
    }
}
