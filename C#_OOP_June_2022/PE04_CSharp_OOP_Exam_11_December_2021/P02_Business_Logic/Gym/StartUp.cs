namespace Gym
{
    using Gym.Core;
    using Gym.Core.Contracts;
    public class StartUp
    {
        public static void Main()
        {
            // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
