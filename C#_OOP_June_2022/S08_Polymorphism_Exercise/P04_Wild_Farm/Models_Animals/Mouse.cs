using System;
using WildFarm.Engine;
using WildFarm.Models_Food;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != Constants.Fruit && food.GetType().Name != Constants.Vegetable)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
            Weight += food.Quantity * Constants.MouseWeightIncrease;
        }

        public override string ProducingSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
