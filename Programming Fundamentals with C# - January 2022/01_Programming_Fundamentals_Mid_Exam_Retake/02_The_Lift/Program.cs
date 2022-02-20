using System;
using System.Linq;

namespace _02_The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var liftCapacity = 4;
            var peopleInTheQueue = int.Parse(Console.ReadLine());

            var allLifts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < allLifts.Count; i++)
            {

                while (allLifts[i] < liftCapacity)
                {
                    if (peopleInTheQueue > 0)
                    {
                        allLifts[i]++;
                        peopleInTheQueue--;
                    }
                    else
                    {
                        break;
                    }
                }
                if (peopleInTheQueue == 0)
                {
                    break;
                }
            }

            if (peopleInTheQueue > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleInTheQueue} people in a queue!");
            }
            else if(allLifts[allLifts.Count - 1] < liftCapacity)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            Console.WriteLine(string.Join(" ", allLifts));
        }
    }
}
