using PlanetWars.Core;
using System;

namespace PlanetWars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Don't forget to comment out the commented code lines in the Engine class!
            var engine = new Engine();

            engine.Run();
        }
    }
}
