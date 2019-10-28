using System;

namespace WeddingHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallLength = double.Parse(Console.ReadLine());
            double hallWidth = double.Parse(Console.ReadLine());
            double barSide = double.Parse(Console.ReadLine());

            double hallArea = hallLength * hallWidth;
            double barArea = barSide * barSide;
            double dancingFloor = hallArea * 0.19;

            double personArea = 3.2;

            double freeSpace = hallArea - barArea - dancingFloor;

            double amountOfPeople = Math.Ceiling(freeSpace / personArea);

            Console.WriteLine(amountOfPeople);
        }
    }
}
