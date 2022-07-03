using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {


        private string name;

        private readonly List<Topping> toppings;
        private Dough dough;
        //private readonly List<Dough> dough;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            toppings = new List<Topping>();
            Dough = dough;
        }


        public Dough Dough
        {
            get { return dough; }
            private set
            {
                dough = value;
            }
        }

        //public IReadOnlyCollection<Dough> Dough
        //{
        //    get { return dough; }
        //}

        //public void AddDough(Dough value)
        //{
        //    dough.Add(value);
        //}

        public IReadOnlyCollection<Topping> Toppings
        {
            get { return toppings; }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || 
                    string.IsNullOrWhiteSpace(value) || 
                    value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }


        public override string ToString()
        {
            
            return $"{Name} - {Dough.Calories + toppings.Sum(x => x.Calories):F2} Calories.";
        }
    }
}
