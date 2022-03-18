using System;

namespace P07_String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var divided = input.Split('>');

            var explosionStrength = 0;
            var remainingExplosionStrength = 0;
            for (int i = 1; i < divided.Length; i++)
            {
                explosionStrength = int.Parse("" + divided[i][0]) + remainingExplosionStrength;
                remainingExplosionStrength = explosionStrength - divided[i].Length;

                if (explosionStrength > divided[i].Length)
                    explosionStrength = divided[i].Length;

                divided[i] = divided[i].Substring(explosionStrength);
                if (remainingExplosionStrength < 0)
                    remainingExplosionStrength = 0;
            }

            var result = string.Join(">", divided);
            Console.WriteLine(result);
        }
    }
}
