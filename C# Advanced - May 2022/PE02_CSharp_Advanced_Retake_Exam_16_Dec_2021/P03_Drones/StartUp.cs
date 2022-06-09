using System;
using System.Collections.Generic;

namespace Drones
{
    public class StartUp
    {
        static void Main()
        {
            // Initialize the repository (Airfield)
            Airfield airfield = new Airfield("Heathrow", 10, 10.5);

            // Initialize entity
            Drone drone = new Drone("D20", "DEERC", 6);

            //Print Drone
            Console.WriteLine(drone);
            // Drone: D20
            // Manufactured by: DEERC
            // Range: 6 kilometers

            // Add Drone
            Console.WriteLine(airfield.AddDrone(drone)); // Successfully added D20 to the airfield.
            Console.WriteLine(airfield.Count); // 1

            // Remove Drone
            Console.WriteLine(airfield.RemoveDrone("DE51"));  // False

            Drone secondDrone = new Drone("CW4", "Cheerwing", 8);
            Drone thirdDrone = new Drone("X5SW-V3", "Cheerwing", 7);
            Drone fourthDrone = new Drone("X20", "Cheerwing", 4);
            Drone fifthDrone = new Drone("EVO2", "Autel", 10);
            Drone sixtDrone = new Drone("XL5-6Sads-FPV", "iFlight", 8);
            Drone stDrone = new Drone("XL5-6Sdsa-FPV", "iFlight", 10);
            Drone siDrone = new Drone("XL5-6Sdsa-FPV", "iFlight", 9);
            Drone sixDrone = new Drone("XL5-6Sdsa-FPV", "iFlight", 10);
            Drone sixtghjDrone = new Drone("XL5-6dasS-FPV", "iFlight", 10);

            // Add Drones
            Console.WriteLine(airfield.AddDrone(secondDrone)); // Successfully added CW4 to the airfield.
            Console.WriteLine(airfield.AddDrone(thirdDrone));  // Successfully added X5SW-V3 to the airfield.
            Console.WriteLine(airfield.AddDrone(fourthDrone)); // Invalid drone.
            Console.WriteLine(airfield.AddDrone(fifthDrone));  // Successfully added EVO2 to the airfield.
            Console.WriteLine(airfield.AddDrone(sixtDrone));   // Successfully added XL5-6S-FPV to the airfield.
            Console.WriteLine(airfield.AddDrone(siDrone));   // Successfully added XL5-6S-FPV to the airfield.
            Console.WriteLine(airfield.AddDrone(sixDrone));   // Successfully added XL5-6S-FPV to the airfield.
            Console.WriteLine(airfield.AddDrone(sixtghjDrone));   // Successfully added XL5-6S-FPV to the airfield.
            Console.WriteLine(airfield.AddDrone(stDrone));   // Successfully added XL5-6S-FPV to the airfield.

            // Fly drone by name
            Console.WriteLine(airfield.FlyDrone("CW44"));
            // Drone: CW4
            // Manufactured by: Cheerwing
            // Range: 8 kilometers

            Console.WriteLine("-----------------FlyDronesByRange-----------------");
            List<Drone> flyDrones = airfield.FlyDronesByRange(10);

            foreach (var droneToFly in flyDrones)
            {
                Console.WriteLine(droneToFly);
            }
            /*
            Drone: EVO2
            Manufactured by: Autel
            Range: 10 kilometers
            Drone: XL5-6S-FPV
            Manufactured by: iFlight
            Range: 10 kilometers
            */
            Console.WriteLine(airfield.RemoveDrone("EVO2"));
            // Remove drone by brand
            Console.WriteLine(airfield.RemoveDroneByBrand("Cheerwing")); // 2

            Console.WriteLine("----------------------Report----------------------");
            Console.WriteLine(airfield.Report());
            /*
            Drones available at Heathrow:
            Drone: D20
            Manufactured by: DEERC
            Range: 6 kilometers
            */

        }
    }
}
