namespace WildFarm.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models_Food;
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string ProducingSound();
        void Eat(Food food);
    }
}
