using Heroes.Core;
using Heroes.Core.Contracts;

namespace Heroes
{
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
