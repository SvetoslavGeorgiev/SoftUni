namespace SpaceStation.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using IO;
    using IO.Contracts;

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
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        string astronautType = input[1];
                        string astronautName = input[2];

                        string result = this.controller.AddAstronaut(astronautType, astronautName);

                        this.writer.WriteLine(result);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string planetName = input[1];
                        string[] items = input
                            .Skip(2)
                            .ToArray();

                        string result = this.controller.AddPlanet(planetName, items);

                        this.writer.WriteLine(result);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        string astronautName = input[1];

                        string result = this.controller.RetireAstronaut(astronautName);

                        this.writer.WriteLine(result);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        string planetName = input[1];

                        string result = this.controller.ExplorePlanet(planetName);

                        this.writer.WriteLine(result);
                    }
                    else if(input[0] == "Report")
                    {
                        string result = this.controller.Report();

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
