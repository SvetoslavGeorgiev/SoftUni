using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string productName;

        private decimal cost;

        public Product(string productName, decimal cost)
        {
            ProductName = productName;
            Cost = cost;
        }

        public decimal Cost
        {
            get { return cost; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Person.Money)} cannot be negative");
                }
                cost = value; 
            }
        }


        public string ProductName
        {
            get { return productName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Person.Name)} cannot be empty");

                }
                productName = value; 
            }
        }

        public override string ToString()
        {
            return $"{productName}";
        }
    }
}
