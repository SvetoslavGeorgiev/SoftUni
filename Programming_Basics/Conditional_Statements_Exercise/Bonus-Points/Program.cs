using System;

namespace Bonus_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            double points = int.Parse(Console.ReadLine());
            double bonusPoints = 0.0;
            if (points > 1000)
            {
                bonusPoints = points * 0.1;
            }
            else if (points > 100 && points <= 1000)
            {
                bonusPoints = points * 0.2;
            }
            else if (points <= 100)
            {
                bonusPoints = 5;
            }
            //zashto imame if i if esle
            if (points % 2 == 0)
            {
                bonusPoints += 1;
            }
            if (points % 10 == 5)
            {
                bonusPoints += 2;
            }
            Console.WriteLine(bonusPoints);
            Console.WriteLine(points + bonusPoints);
        }
    }
}
