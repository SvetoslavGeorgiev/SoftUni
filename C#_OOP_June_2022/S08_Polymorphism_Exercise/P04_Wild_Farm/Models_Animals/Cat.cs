namespace WildFarm.Models
{
    using System;
    using WildFarm.Engine;
    using WildFarm.Models_Food;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != Constants.Meat && food.GetType().Name != Constants.Vegetable)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
            Weight += food.Quantity * Constants.CatWeightIncrease;
        }

        public override string ProducingSound()
        {
            return "Meow";
        }
    }
}
