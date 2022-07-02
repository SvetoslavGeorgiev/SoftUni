using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {

        private string name;

        private decimal money;

        private readonly List<Product> bag;


        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }

        public IReadOnlyCollection<Product> Bag
        {
            get { return bag; }
        }

        public decimal Money
        {
            get { return money; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Money)} cannot be negative");
                }
                money = value; 
            }
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Name)} cannot be empty");

                }
                name = value; 
            }
        }

        public void AddProduct(Product product)
        {
            if (product.Cost > Money)
            {
                throw new ArgumentException($"{Name} can't afford {product.ProductName}");
            }
            bag.Add(product);
            Money -= product.Cost;
            Console.WriteLine($"{Name} bought {product.ProductName}");
        }

        public override string ToString()
        {
            if (bag.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }
            else
            {
                return $"{Name} - {string.Join(", ", Bag)}";
            }
        }
    }
}
