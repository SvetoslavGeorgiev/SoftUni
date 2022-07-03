using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {


        private string flourType;
        private string bakingTechnique;
        private int grams;
        private double calories;

        public Dough(string flourType, string bakingTechnique, int grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value;
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set 
            {
                if (value.ToLower() != "crispy" && 
                    value.ToLower() != "chewy" && 
                    value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value; 
            }
        }


        public string FlourType
        {
            get { return flourType; }
            private set 
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        private double GetDoughCalories(double value)
        {
            switch (FlourType.ToLower())
            {
                case "white":
                    value = 1.5 * value;
                    break;
                case "wholegrain":
                    value = 1.0 * value;
                    break;
                default:
                    break;
            }
            switch (BakingTechnique.ToLower())
            {
                case "crispy":
                    value = 0.9 * value;
                    break;
                case "chewy":
                    value = 1.1 * value;
                    break;
                case "homemade":
                    value = 1.0 * value;
                    break;
                default:
                    break;
            }

            return value * 2;
        }

    }
}
