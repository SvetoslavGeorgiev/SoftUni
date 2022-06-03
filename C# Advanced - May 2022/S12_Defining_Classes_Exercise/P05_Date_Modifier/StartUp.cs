using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();
            var date = new DateModifier();

            var days = Math.Abs(date.GetTimeSpan(firstDate, secondDate));

            Console.WriteLine(days);
        }
    }
}
