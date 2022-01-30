using System;

namespace _01_Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wagons = int.Parse(Console.ReadLine());

            var train = new int[wagons];
            var passengersInTrain = 0;
            for (int i = 0; i < wagons; i++)
            {
                var passengers = int.Parse(Console.ReadLine());
                train[i] = passengers;
                passengersInTrain += passengers;
            }

            Console.WriteLine(string.Join(" ", train));
            Console.WriteLine(passengersInTrain);
        }
    }
}