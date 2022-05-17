using System;
using System.Collections.Generic;

namespace P10_Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var greenLight = int.Parse(Console.ReadLine());

            var freeWindow = int.Parse(Console.ReadLine());

            var commandOrCar = string.Empty;

            var counter = 0;

            Queue<string> carsAtTheLigth = new Queue<string>();

            while ((commandOrCar = Console.ReadLine()) != "END")
            {

                if (commandOrCar != "green")
                {
                    carsAtTheLigth.Enqueue(commandOrCar);
                }
                else
                {
                    var currentCar = string.Empty;
                    var currentGreenLight = greenLight;

                    while (currentGreenLight > 0 && carsAtTheLigth.Count > 0)
                    {
                        currentCar = carsAtTheLigth.Dequeue();
                        counter++;
                        currentGreenLight -= currentCar.Length;
                    }
                    if (currentGreenLight == 0)
                    {
                        continue;
                    }
                    if (currentGreenLight < 0)
                    {

                        currentGreenLight += freeWindow;

                        if (currentGreenLight >= 0)
                        {
                            //counter++;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[currentCar.Length + currentGreenLight]}.");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
