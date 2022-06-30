using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main()
        {

            var sportCar = new SportCar(159, 45.25);
            var famylyCar = new FamilyCar(99, 45.25);
            var raceMotor = new RaceMotorcycle(120, 45.25);
            var crossMotor = new CrossMotorcycle(180, 45.25);


            Console.WriteLine(sportCar);
            Console.WriteLine(famylyCar);
            Console.WriteLine(raceMotor);
            Console.WriteLine(crossMotor);

            sportCar.Drive(4.25);
            famylyCar.Drive(4.25);
            raceMotor.Drive(4.25);
            crossMotor.Drive(4);

            Console.WriteLine(sportCar);
            Console.WriteLine(famylyCar);
            Console.WriteLine(raceMotor);
            Console.WriteLine(crossMotor);

            
        }
    }
}
