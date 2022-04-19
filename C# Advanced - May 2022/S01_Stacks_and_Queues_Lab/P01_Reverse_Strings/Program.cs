using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();


            Stack<char> stack = new Stack<char>();

            foreach (var item in command)
            {
                stack.Push(item);
            }

            foreach (var item in stack)
            {
                Console.Write(item);
            }
        }
    }
}