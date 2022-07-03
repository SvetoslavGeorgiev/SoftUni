using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;

        private int grams;

        private double calories;

        public Topping(string type, int grams)
        {
            Type = type;
            Grams = grams;
            Calories = calories;
        }

        public double Calories
        {
            get { return calories; }
            private set
            {
                value = Grams * 1.00;
                calories = GetDoughCalories(value);
            }
        }


        public int Grams
        {
            get { return grams; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }

        public string Type
        {
            get { return type; }
            private set
            {
                if (value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        private double GetDoughCalories(double value)
        {
            switch (Type.ToLower())
            {
                case "meat":
                    value = value * 1.2;
                    break;
                case "veggies":
                    value = value * 0.8;
                    break;
                case "cheese":
                    value = value * 1.1;
                    break;
                case "sauce":
                    value = value * 0.9;
                    break;
                default:
                    break;
            }
            return value * 2;
        }


    }
}
