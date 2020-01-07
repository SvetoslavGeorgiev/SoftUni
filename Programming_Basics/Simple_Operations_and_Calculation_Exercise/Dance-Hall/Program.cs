using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenghtHall = double.Parse(Console.ReadLine());
            double widthHall = double.Parse(Console.ReadLine());
            double sideOfwardrobe = double.Parse(Console.ReadLine());

            double areaHallInCentim = (lenghtHall * 100) * (widthHall * 100);
            double sideOfwardrobeInCentim = sideOfwardrobe * 100;

            double areaWardrobeInCentim = sideOfwardrobeInCentim * sideOfwardrobeInCentim;
            double areaBenchInCentim = areaHallInCentim / 10;
            double freeArea = areaHallInCentim - areaWardrobeInCentim - areaBenchInCentim;
            double amountOfpeople = freeArea / (7000 + 40);

            Console.WriteLine((int)amountOfpeople);


        }
    }
}
