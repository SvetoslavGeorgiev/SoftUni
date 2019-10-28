using System;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double widthShip = double.Parse(Console.ReadLine());
            double lenghtShip = double.Parse(Console.ReadLine());
            double hightShip = double.Parse(Console.ReadLine());
            double hightOfAstronaft = double.Parse(Console.ReadLine());

            double areaOfTheShip = widthShip * lenghtShip * hightShip;

            double areaOfTheRoom = 2 * 2 * (hightOfAstronaft + 0.40);

            double amountofAstronauts = Math.Floor(areaOfTheShip / areaOfTheRoom);

            if (amountofAstronauts < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (amountofAstronauts >= 3 && amountofAstronauts <= 10)
            {
                Console.WriteLine($"The spacecraft holds {amountofAstronauts} astronauts.");
            }
            else
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
