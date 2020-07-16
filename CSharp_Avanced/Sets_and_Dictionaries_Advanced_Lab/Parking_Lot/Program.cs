using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();
            var command = string.Empty;

            while ((command = Console.ReadLine().ToUpper()) != "END")
            {
                var line = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var direction = line[0];
                var regNumber = line[1];

                parkingLot.Add(regNumber);
                 
                if (direction == "OUT" && parkingLot.Contains(regNumber))
                {
                    parkingLot.Remove(regNumber);
                }

            }

            if (parkingLot.Any())
            {
                foreach (var reg in parkingLot)
                {
                    Console.WriteLine(reg);
                }
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }

        }
    }
}
