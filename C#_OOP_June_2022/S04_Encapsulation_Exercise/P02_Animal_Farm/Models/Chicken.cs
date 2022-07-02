namespace AnimalFarm.Models
{
    using System;
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;
        public double productPerDay;

        public Chicken(string name, int age)
        {
            Name = name;
            Age = age;
            ProductPerDay = productPerDay;
        }

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Name)} cannot be empty.");
                }
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            private set
            {
                if (!(value > MinAge && value < MaxAge))
                {
                    throw new ArgumentException($"{nameof(Age)} should be between 0 and 15.");
                }
                age = value;
            }
        }

        public double ProductPerDay
        {
			get
			{
                return productPerDay;

            }
            private set
            {
                productPerDay = CalculateProductPerDay();

            }
        }

        private double CalculateProductPerDay()
        {
            switch (Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}
