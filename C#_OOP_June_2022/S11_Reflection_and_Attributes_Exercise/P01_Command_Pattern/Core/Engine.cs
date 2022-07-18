namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            var input = Console.ReadLine();

            var result = commandInterpreter.Read(input);

            Console.WriteLine(result);
        }
    }
}
