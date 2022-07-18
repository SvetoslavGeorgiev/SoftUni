namespace CommandPattern
{
    using System;
    using Core.Contracts;
    using Core;

    public class StartUp
    {
        static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
