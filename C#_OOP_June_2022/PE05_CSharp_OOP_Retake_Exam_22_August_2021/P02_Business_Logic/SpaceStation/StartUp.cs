namespace SpaceStation
{
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}