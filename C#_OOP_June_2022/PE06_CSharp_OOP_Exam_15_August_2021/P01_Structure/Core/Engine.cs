// ReSharper disable InconsistentNaming
// ReSharper disable FunctionNeverReturns
namespace CarRacing.Core
{
    using System;
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
            //this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddCar")
                    {
                        string type = input[1];
                        string make = input[2];
                        string model = input[3];
                        string VIN = input[4];
                        int horsePower = int.Parse(input[5]);

                        result = controller.AddCar(type, make, model, VIN, horsePower);
                    }
                    else if (input[0] == "AddRacer")
                    {
                        string type = input[1];
                        string username = input[2];
                        string carVIN = input[3];

                        result = controller.AddRacer(type, username, carVIN);
                    }
                    else if (input[0] == "BeginRace")
                    {
                        string racerOneUsername = input[1];
                        string racerTwoUsername = input[2];

                        result = controller.BeginRace(racerOneUsername, racerTwoUsername);
                    }
                    else if (input[0] == "Report")
                    {
                        result = controller.Report();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
