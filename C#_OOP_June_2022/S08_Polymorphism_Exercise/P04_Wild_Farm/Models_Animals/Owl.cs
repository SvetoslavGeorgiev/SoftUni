using System;
using WildFarm.Engine;
using WildFarm.Models_Food;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != Constants.Meat)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
            Weight += food.Quantity * Constants.OwlWeightIncrease;
        }

        public override string ProducingSound()
        {
            return "Hoot Hoot";
        }
    }
}
