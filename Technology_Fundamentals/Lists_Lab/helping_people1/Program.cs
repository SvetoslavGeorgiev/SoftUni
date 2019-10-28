using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            int counter = 0;

            while (command != "end")
            {
                string[] token = command.Split();
                if (token[0] == "Add"
                    || token[0] == "Remove"
                    || token[0] == "RemoveAt"
                    || token[0] == "Insert")
                {
                    counter++;
                }

                if (token[0] == "Add")
                {
                    numbers.Add(int.Parse(token[1]));
                }
                else if (token[0] == "Remove")
                {
                    numbers.Remove(int.Parse(token[1]));
                }
                else if (token[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(token[1]));
                }
                else if (token[0] == "Insert")
                {
                    int number = int.Parse(token[1]);
                    int index = int.Parse(token[2]);
                    numbers.Insert(index, number);
                }
                else if (token[0] == "Contains")
                {
                    int number = int.Parse(token[1]);

                    //for (int i = 0; i < numbers.Count; i++)
                    //{
                    //    if (numbers[i] == number)
                    //    {
                    //        counter++;
                    //    }
                    //}

                    if (numbers.Contains(number))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (token[0] == "PrintEven")
                {
                    //for (int i = 0; i < numbers.Count; i++)
                    //{
                    //    int evenOrOdd = numbers[i];

                    //    if (evenOrOdd % 2 == 0)
                    //    {
                    //        Console.Write(evenOrOdd + " ");
                    //    }
                    //}

                    //Console.WriteLine();
                    var evenNumbers = numbers.FindAll(item => item % 2 == 0);
                    Console.WriteLine(string.Join(" ", evenNumbers));
                }
                else if (token[0] == "PrintOdd")
                {
                    //for (int i = 0; i < numbers.Count; i++)
                    //{
                    //    int oddNumber = numbers[i];

                    //    if (oddNumber % 2 != 0)
                    //    {
                    //        Console.Write(oddNumber + " ");
                    //    }
                    //}

                    //Console.WriteLine();
                    var oddNumbers = numbers.FindAll(item => item % 2 != 0);
                    Console.WriteLine(string.Join(" ", oddNumbers));
                }
                else if (token[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (token[0] == "Filter")
                {
                    if (token[1] == "<")
                    {
                        int number = int.Parse(token[2]);

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < number)
                            {
                                Console.Write(string.Join(" ", numbers[i]) + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (token[1] == ">")
                    {
                        int number = int.Parse(token[2]);

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] > number)
                            {
                                Console.Write(string.Join(" ", numbers[i]) + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (token[1] == ">=")
                    {
                        int number = int.Parse(token[2]);

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] >= number)
                            {
                                Console.Write(string.Join(" ", numbers[i]) + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        int number = int.Parse(token[2]);

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] <= number)
                            {
                                Console.Write(string.Join(" ", numbers[i] + " "));
                            }
                        }
                        Console.WriteLine();
                    }
                }
                command = Console.ReadLine();
            }
            if (counter > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}