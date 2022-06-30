using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            var zoo = new List<Animal>();


            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Beast!")
            {

                

                var type = command;

                var tokens = Console.ReadLine().Split(" ");
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var gender = tokens[2];

                if (type == "Cat")
                {
                    zoo.Add(new Cat(name, age, gender));
                    
                }
                else if (type == "Dog")
                {
                    zoo.Add(new Dog(name, age, gender));
                }
                else if (type == "Kitten")
                {
                    zoo.Add(new Kitten(name, age));
                }
                else if (type == "TomCat")
                {
                    zoo.Add(new Tomcat(name, age));
                }
                else
                {
                    zoo.Add(new Frog(name, age, gender));
                }
            }

            
            foreach (var animal in zoo)
            {

                Console.WriteLine(animal.Type);
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());


            }
        }
    }
}
