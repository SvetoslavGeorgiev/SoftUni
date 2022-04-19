using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            var command = string.Empty;
            var numbers = new Stack<int>();
            var sum = 0;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                var command1 = command.Split();

                if (command1[0] == "add")
                {
                    numbers.Push(int.Parse(command1[1]));
                    numbers.Push(int.Parse(command1[2]));
                }
                else if (command1[0] == "remove")
                {
                    var loopNumber = int.Parse(command1[1]);
                    if (loopNumber > numbers.Count)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 1; i <= loopNumber; i++)
                        {
                            numbers.Pop();
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < command1.Length; i++)
                    {
                        numbers.Push(int.Parse(command1[i]));
                    }
                }
            }


            while (numbers.Any())
            {
                sum += numbers.Pop();
            }

            Console.WriteLine($"Sum: {sum}");

        }
    }
}
