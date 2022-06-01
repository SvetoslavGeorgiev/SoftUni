using System;
using System.Linq;

namespace P11_TriFunction
{
    public class P11_TriFunction
    {
        static void Main()
        {

            var number = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> func = (x, y) =>
            {
                int sum = 0;
                foreach (var item in x)
                {
                    sum += item;
                    if (sum >= y)
                    {
                        return true;
                    }
                }
                return false;
            };

            var name = names.Where(x => func(x, number));

            Console.WriteLine(name);
        }
    }
}
