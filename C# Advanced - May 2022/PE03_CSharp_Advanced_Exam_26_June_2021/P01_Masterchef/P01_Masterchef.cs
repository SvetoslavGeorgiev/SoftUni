using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp66
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<int> list = new List<int>();

            List<int> first = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Queue<int> ingredients = new Queue<int>(first);

            int[] second = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> freshness = new Stack<int>(second);

            var readyDishes = new Dictionary<string, int>
            {
                {"Dipping sauce", 0},
                {"Green salad", 0},
                {"Chocolate cake", 0},
                {"Lobster", 0}
            };
            int n = first.Count;
            while (ingredients.Count > 0 && freshness.Count > 0)
            {

                int a = ingredients.Peek();


                if (a == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int b = freshness.Pop();
                int sum = a * b;

                if (sum == 150)
                {
                    readyDishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                }
                else if (sum == 250)
                {
                    readyDishes["Green salad"]++;
                    ingredients.Dequeue();
                }
                else if (sum == 300)
                {
                    readyDishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                }
                else if (sum == 400)
                {
                    readyDishes["Lobster"]++;
                    ingredients.Dequeue();
                }
                else
                {
                    ingredients.Enqueue(ingredients.Dequeue() + 5);
                }

            }

            if (readyDishes["Green salad"] > 0 && readyDishes["Green salad"] > 0 && readyDishes["Chocolate cake"] > 0 && readyDishes["Lobster"] > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");

            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            var filtered = readyDishes.Where(dish => dish.Value > 0).OrderBy(dish => dish.Key);
            foreach (var (dish, amount) in filtered)
            {
                Console.WriteLine($" # {dish} --> {amount}");
            }


        }
    }
}
