using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCarsToPass = int.Parse(Console.ReadLine());

            var commandOrCar = Console.ReadLine();

            var queueAtTrafficLight = new Queue<string>();
            var counter = 0;

            while (commandOrCar != "end")
            {

                while (commandOrCar != "green")
                {
                    if (commandOrCar == "end")
                    {
                        Console.WriteLine($"{counter} cars passed the crossroads.");
                        return;
                    }
                    queueAtTrafficLight.Enqueue(commandOrCar);

                    commandOrCar = Console.ReadLine();
                }
                var smallerOfTheTwo = Math.Min(numberOfCarsToPass, queueAtTrafficLight.Count);
                for (int i = 1; i <= smallerOfTheTwo; i++)
                {
                    Console.WriteLine($"{queueAtTrafficLight.Dequeue()} passed!");
                    counter++;
                }

                commandOrCar = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
