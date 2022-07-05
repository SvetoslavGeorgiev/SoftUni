﻿namespace FoodShortage.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class CommandParser
    {

        public Command Parse(string command)
        {
            var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return new Command
            {
                Arguments = tokens.ToArray()
            };
        }
    }
}
