using System;

namespace Farm
{
    public class StartUp
    {
        static void Main()
        {
            var puppy = new Puppy();

            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
        }
    }
}
