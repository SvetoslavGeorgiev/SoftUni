using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            

            int[] checkList = numbers.ToArray();

            var counter = 0;

            string command = Console.ReadLine();

            while (command != "end")
            {
                

                string[] temp = command.Split();

                if (temp[0] == "Add"
                    || temp[0] == "Remove"
                    || temp[0] == "RemoveAt"
                    || temp[0] == "Insert")
                {
                    counter++;
                }

                if (temp[0] == "Add")
                {
                    numbers.Add(int.Parse(temp[1]));
                }
                else if (temp[0] == "Remove")
                {
                    numbers.Remove(int.Parse(temp[1]));
                }
                else if (temp[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(temp[1]));
                }
                else if (temp[0] == "Insert")
                {
                    int number = int.Parse(temp[1]);
                    int index = int.Parse(temp[2]);
                    numbers.Insert(index, number);
                }
                else if (temp[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(temp[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }

                }
                else if (temp[0] == "PrintEven")
                {

                    numbers.RemoveAll(item => item % 2 != 0);
                    Console.WriteLine(string.Join(" ", numbers));
                    numbers = checkList.ToList();
                }
                else if (temp[0] == "PrintOdd")
                {

                    numbers.RemoveAll(item => item % 2 == 0);
                    Console.WriteLine(string.Join(" ", numbers));
                    numbers = checkList.ToList();
                }
                else if (temp[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (temp[0] == "Filter")
                {
                    int number = int.Parse(temp[2]);
                    
                    if (temp[1] == ">=")
                    {
                        Console.WriteLine(string.Join(" ", numbers.FindAll(item => item >= number)));
                    }
                    else if (temp[1] == "<=")
                    {
                        Console.WriteLine(string.Join(" ", numbers.FindAll(item => item <= number)));
                    }
                    else if (temp[1] == ">")
                    {
                        Console.WriteLine(string.Join(" ", numbers.FindAll(item => item > number)));
                    }
                    else if (temp[1] == "<")
                    {
                        Console.WriteLine(string.Join(" ", numbers.FindAll(item => item < number)));
                    }
                }
                command = Console.ReadLine();
            }

            if (counter != 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
