using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {


            try
            {
                var command = Console.ReadLine();
                var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 1)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                
                var command1 = Console.ReadLine();
                var tokens1 = command1.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var dough = new Dough(tokens1[1], tokens1[2], int.Parse(tokens1[3]));
                var pizza = new Pizza(tokens[1], dough);
                while ((command = Console.ReadLine()).ToLower() != "end")
                {

                    tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var topping = new Topping(tokens[1], int.Parse(tokens[2]));
                    pizza.AddTopping(topping);

                }
                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }
    }
}