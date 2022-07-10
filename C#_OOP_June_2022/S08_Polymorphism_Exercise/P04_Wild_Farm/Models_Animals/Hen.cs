using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Engine;
using WildFarm.Models_Food;

namespace WildFarm.Models
{
    internal class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        public override void Eat(Food food)
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * Constants.HenWeightIncrease;
        }

        public override string ProducingSound()
        {
            return "Cluck";
        }
    }
}
