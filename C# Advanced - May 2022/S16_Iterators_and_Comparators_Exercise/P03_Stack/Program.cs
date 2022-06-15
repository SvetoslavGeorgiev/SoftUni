using System;
using System.Linq;

namespace P03_Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();

            var command = string.Empty;

            while ((command = Console.ReadLine().TrimEnd()) != "END")
            {

                var tokens = command.Split();

                if (tokens[0] == "Push")
                {
                    stack.Push(tokens.Skip(1).Select(x => x.Split(",").First()).ToArray());
                }
                else if (tokens[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }



            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

        }
    }
}
