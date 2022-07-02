using System;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            (var length, var width, var height) = (double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));

            Box box;

            try
            {
                box = new Box(length, width, height);

            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
                return;
            }

            Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
            Console.WriteLine($"Volume - {box.Volume():F2}");
        }
    }
}
