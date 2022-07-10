namespace Raiding.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class CommandParser
    {
        public Command HeroParse(string command)
        {
            var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return new Command
            {
                HeroType = tokens[0],
                HeroName = tokens[1]
            };
        }
    }
}
