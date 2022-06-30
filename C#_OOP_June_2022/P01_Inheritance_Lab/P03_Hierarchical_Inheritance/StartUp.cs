using System;

namespace Farm
{
    public class StartUp
    {
        static void Main()
        {
            var dog = new Dog();

            dog.Eat();
            dog.Bark();

            var cat = new Cat();

            cat.Eat();
            cat.Meow();
        }
    }
}
