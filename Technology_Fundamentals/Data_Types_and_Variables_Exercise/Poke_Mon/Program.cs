using System;

namespace Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int power = 0;
            double half = n * 0.5;
            int pokeCouter = 0;
            while (n >= m)
            {
                pokeCouter++;
                power = n - m;
                n = power;


                if (n == half && y > 0)
                {
                    n /= y;
                }
            }
            Console.WriteLine(n);
            Console.WriteLine(pokeCouter);
        }
    }
}
