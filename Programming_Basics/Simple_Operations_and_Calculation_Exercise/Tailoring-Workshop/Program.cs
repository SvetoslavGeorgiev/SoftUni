using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int recTablesAmount = int.Parse(Console.ReadLine());
            double lenghtRecTables = double.Parse(Console.ReadLine());
            double widthRecTables = double.Parse(Console.ReadLine());
            double sideOfSquTables = lenghtRecTables / 2;
            int squTablesAmount = recTablesAmount;

            double areaRecTables = recTablesAmount * (lenghtRecTables + 2 * 0.30) * (widthRecTables + 2 * 0.3);
            double areaSquTables = squTablesAmount * (lenghtRecTables / 2) * (lenghtRecTables / 2);
            double sumInUSD = areaRecTables * 7 + areaSquTables * 9;
            double sumInBGN = sumInUSD * 1.85;

            Console.WriteLine($"{sumInUSD:F2} USD");
            Console.WriteLine($"{ sumInBGN:F2} BGN");
        }
    }
}
