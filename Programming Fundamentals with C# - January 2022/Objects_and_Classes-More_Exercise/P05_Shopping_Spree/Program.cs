using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listOfPeople = new List<Person>();

            var listOfProducts = new List<Product>();

            var people = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var person in people)
            {
                var tokens = person.Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var newPerson = new Person(tokens[0], decimal.Parse(tokens[1]));

                listOfPeople.Add(newPerson);
            }

            var products = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var product in products)
            {
                var tokens = product
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var newProduct = new Product(tokens[0], decimal.Parse(tokens[1]));

                listOfProducts.Add(newProduct);
            }

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                var input = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var person = input[0];
                var product = input[1];

                if (!listOfPeople.Any(x => x.Name == person))
                {
                    continue;
                }
                if (!listOfProducts.Any(x => x.Name == product))
                {
                    continue;
                }

                foreach (var item in listOfProducts)
                {
                    if (item.Name == product)
                    {
                        
                        if (listOfPeople.Find(p => p.Name == person).Money >= item.Cost)
                        {
                            listOfPeople.Find(p => p.Name == person && p.Money >= item.Cost).BagOfProducts.Add(item);
                            listOfPeople.Find(p => p.Name == person).Money -= item.Cost;
                            Console.WriteLine($"{person} bought {product}");
                        }
                        else
                        {
                            Console.WriteLine($"{person} can't afford {product}");
                        }
                    }
                }
            }

            foreach (var p in listOfPeople)
            {
                if (p.BagOfProducts.Count > 0)
                {
                    var allProducts = new StringBuilder();
                    for (int i = 0; i < p.BagOfProducts.Count; i++)
                    {
                        if (i == p.BagOfProducts.Count - 1)
                        {
                            allProducts.Append(p.BagOfProducts[i].Name);
                        }
                        else
                        {
                            allProducts.Append($"{p.BagOfProducts[i].Name}, ");
                        }
                    }
                    Console.WriteLine($"{p.Name} - {allProducts}");
                }
                else
                {
                    Console.WriteLine($"{p.Name} - Nothing bought");
                }
            }
        }
    }

    class Person
    {
        public Person()
        {

        }
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }
        public Person(string name, decimal money, List<Product> bagOfProducts)
        {
            Name = name;
            Money = money;
            BagOfProducts = bagOfProducts;
        }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<Product> BagOfProducts { get; set; }
    }

    class Product
    {
        public Product()
        {

        }
        public Product(string name, decimal cost)
        {
            Name=name;
            Cost = cost;
        }
        public decimal Cost { get; set; }
        public string Name { get; set; }
    }
}
