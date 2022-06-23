using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Birthday_Celebration
{
    public class P01_Birthday_Celebration
    {
        static void Main()
        {
            var guests = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            var plates = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            var footWaste = 0;
            while (guests.Any() && plates.Any())
            {

                var currentGuest = guests.Dequeue();
                var currentPlate = plates.Pop();

                
                while (currentGuest > currentPlate)
                {
                    currentGuest -= currentPlate;

                    if (currentGuest <= 0)
                    {
                        footWaste -= Math.Abs(currentGuest);
                        break;
                    }
                    if (plates.Any())
                    {
                        currentPlate = plates.Pop();
                    }
                }
                footWaste += currentPlate - currentGuest;

            }

            if (plates.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {footWaste}");
        }
    }
}
