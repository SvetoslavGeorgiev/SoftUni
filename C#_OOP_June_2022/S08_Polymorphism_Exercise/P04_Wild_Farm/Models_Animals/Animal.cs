using WildFarm.Contracts;
using WildFarm.Models_Food;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        private string name;

        private double weight;

        private int foodEaten;

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public int FoodEaten
        {
            get => foodEaten;
            protected set 
            { 
                foodEaten = value; 
            }
        }

        public double Weight
        {
            get => weight;
            protected set 
            { 
                weight = value; 
            }
        }


        public string Name
        {
            get => name;
            protected set 
            { 
                name = value; 
            }
        }

        public abstract void Eat(Food food);

        

        public abstract string ProducingSound();

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
