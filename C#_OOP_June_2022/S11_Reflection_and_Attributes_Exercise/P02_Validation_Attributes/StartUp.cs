namespace ValidationAttributes
{
    using System;
    using Models;
    public class StartUp
    {
        public static void Main()
        {
            var person = new Person
             (
                 null,
                 -1
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
