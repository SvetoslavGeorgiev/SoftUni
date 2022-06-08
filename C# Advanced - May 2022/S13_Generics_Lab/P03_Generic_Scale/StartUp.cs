using System;

namespace P03_Generic_Scale
{
    public class StartUp
    {
        static void Main()
        {
            var equals = new EqualityScale<int>(1, 1);

            var result = equals.AreEqual();

            Console.WriteLine(result);
        }
    }
}
