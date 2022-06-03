using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var numberOfEngines = int.Parse(Console.ReadLine());

            var engineCatalog = new Dictionary<string, Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                var tokens = new Queue(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

                var engine = new Engine(tokens.Dequeue().ToString(), int.Parse(tokens.Dequeue().ToString()));

                while (tokens.Count != 0)
                {
                    bool isInt = int.TryParse(tokens.Peek().ToString(), out int value);
                    if (isInt)
                    {
                        engine.Displacement = value;
                        tokens.Dequeue();
                    }
                    else
                    {
                        engine.Efficiency = tokens.Dequeue().ToString();
                    }
                }



                engineCatalog.Add(engine.Model, engine);
            }


            var numberOfCars = int.Parse(Console.ReadLine());

            var carList = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var tokens = new Queue(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

                var car = new Car(tokens.Dequeue().ToString(), engineCatalog[tokens.Dequeue().ToString()]);


                while (tokens.Count != 0)
                {
                    
                    bool isInt = int.TryParse(tokens.Peek().ToString(), out int value);
                    if (isInt)
                    {
                        car.Weight = value;
                        tokens.Dequeue();
                    }
                    else
                    {
                        car.Color = tokens.Dequeue().ToString();
                    }
                }

                carList.Add(car);
            }


            foreach (var car in carList)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
