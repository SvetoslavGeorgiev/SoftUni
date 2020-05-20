using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BalancedParenthesis
{
    static void Main()
    {
        var numberOfOperations = int.Parse(Console.ReadLine());

        Stack<string> updates = new Stack<string>();

        StringBuilder text = new StringBuilder();

        updates.Push(text.ToString());

        for (int i = 1; i <= numberOfOperations; i++)
        {

            var command = Console.ReadLine().Split().ToArray();

            if (command[0] == "1")
            {
                
                text.Append(command[1]);
                updates.Push(text.ToString());

            }
            else if (command[0] == "2")
            {
                var countToErase = int.Parse(command[1]);

                if (countToErase >= text.Length)
                {
                    text.Clear();
                    updates.Push(text.ToString());
                   //Console.WriteLine(updates.Peek());
                }
                else
                {
                    text.Remove(text.Length - countToErase, countToErase);
                    updates.Push(text.ToString());
                }
            }
            else if (command[0] == "3")
            {
                var charToPeek = int.Parse(command[1]);
                Console.WriteLine(text[charToPeek - 1]);
            }
            else
            {
                text.Clear();
                updates.Pop();
                text.Append(updates.Peek());
            }
        }
    }
}