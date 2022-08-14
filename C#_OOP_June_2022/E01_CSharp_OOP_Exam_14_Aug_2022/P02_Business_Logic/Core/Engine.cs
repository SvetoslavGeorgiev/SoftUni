using PlanetWars.Core.Contracts;
using PlanetWars.IO;
using PlanetWars.IO.Contracts;
using System;

namespace PlanetWars.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if(input[0] == "Peace")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "CreatePlanet")
                    {
                        string planetName = input[1];
                        double budget = double.Parse(input[2]);

                        string result = this.controller.CreatePlanet(planetName, budget);
                        this.writer.WriteLine(result);
                    }
                    if (input[0] == "AddUnit")
                    {
                        string unitTypeName = input[1];
                        string planetName = input[2];


                        string result = this.controller.AddUnit(unitTypeName, planetName);
                        this.writer.WriteLine(result);
                    }
                    if (input[0] == "AddWeapon")
                    {
                        string planetName = input[1];
                        string weaponTypeName = input[2];
                        int destructionLevel = int.Parse(input[3]);

                        string result = this.controller.AddWeapon(planetName, weaponTypeName, destructionLevel);
                        this.writer.WriteLine(result);
                    }
                    if (input[0] == "SpecializeForces")
                    {
                        string planetName = input[1];

                        string result = this.controller.SpecializeForces(planetName);
                        this.writer.WriteLine(result);
                    }
                    if (input[0] == "SpaceCombat")
                    {
                        string planetOne = input[1];
                        string planetTwo = input[2];

                        string result = this.controller.SpaceCombat(planetOne, planetTwo);
                        this.writer.WriteLine(result);
                    }
                    else if (input[0] == "ForcesReport")
                    {
                        string result = this.controller.ForcesReport();
                        this.writer.WriteLine(result);
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
