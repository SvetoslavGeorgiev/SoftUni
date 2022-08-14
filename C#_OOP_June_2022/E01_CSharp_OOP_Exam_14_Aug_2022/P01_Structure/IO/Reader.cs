using PlanetWars.IO.Contracts;
using System;

namespace PlanetWars.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
