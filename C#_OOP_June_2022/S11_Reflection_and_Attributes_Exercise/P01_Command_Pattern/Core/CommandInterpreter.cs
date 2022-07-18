namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var tokens = args.Split(' ');

            var commandName = $"{tokens[0]}Command";
            var aguments = tokens.Skip(1).ToArray();

            var type = Assembly
                .GetCallingAssembly()
                .GetType($"CommandPattern.Core.{commandName}");

            //var type = Assembly
            //    .GetCallingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(t => t.Name == commandName);


            var command = (ICommand)Activator.CreateInstance(type);

            var result = command.Execute(aguments);

            return result;
        }
    }
}
