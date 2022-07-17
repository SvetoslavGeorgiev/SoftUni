namespace Stealer
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var spy = new Spy();
            var result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}
