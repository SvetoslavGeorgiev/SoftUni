using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            while (input1.Contains("()") || input1.Contains("[]") || input1.Contains("{}"))
            {
                input1 = input1.Replace("()", "");
                input1 = input1.Replace("[]", "");
                input1 = input1.Replace("{}", "");
            }

            var input = input1.ToCharArray();
            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            else
            {
                for (int i = 1; i <= input.Length / 2; i++)
                {
                    stack.Push(input[i - 1]);
                    queue.Enqueue(input[(i - 1) + (input.Length / 2)]);
                }

                while (stack.Any())
                {
                    var symbol = stack.Pop();
                    if (symbol == '(')
                    {
                        symbol = ')';
                    }
                    else if (symbol == '[')
                    {
                        symbol = ']';
                    }
                    else if (symbol == '{')
                    {
                        symbol = '}';
                    }
                    else
                    {
                        symbol = ' ';
                    }



                    if (!symbol.Equals(queue.Dequeue()))
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                }
                Console.WriteLine("YES");
            }
        }
    }
}
