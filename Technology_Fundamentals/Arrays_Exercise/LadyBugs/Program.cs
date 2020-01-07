using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            string[] indexesOfLadybugs = Console.ReadLine().Split().ToArray();

            Array.Resize<string>(ref indexesOfLadybugs, fieldSize);

            int[] field = new int[fieldSize];

            for (int i = 0; i < fieldSize; i++)
            {
                if (indexesOfLadybugs[i] != null)
                {
                    int num = int.Parse(indexesOfLadybugs[i]);
                    field[num] = 1;
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] command2 = command.Split().ToArray();

                int moovingFrom = int.Parse(command2[0]);
                int moovingTo = int.Parse(command2[2]); ;

                if (moovingTo >= fieldSize)
                {
                    break;
                }
                else if (command2[1] == "right")
                {
                    if (field[moovingFrom] != 1)
                    {
                        break;
                    }
                    else if (field[moovingFrom] == 1)
                    {
                        field[moovingFrom] = 0;
                        if (field[moovingTo] == 0)
                        {
                            field[moovingTo] = 1;
                            break;
                        }
                        else if (field[moovingTo] == 1)
                        {
                            
                            for (int i = (field[moovingTo]); i <= int.MinValue; i+= moovingTo)
                            {
                                if (field[i] >= fieldSize)
                                {
                                    field[i - moovingTo] = 0;
                                    break;
                                }
                                else
                                {
                                    if (field[i] == 0)
                                    {
                                        field[i] = 1;
                                    }
                                    else
                                    {
                                        field[i] = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    if (field[moovingFrom] != 1)
                    {
                        break;
                    }
                    else if (field[moovingFrom] == 1)
                    {
                        field[moovingFrom] = 0;
                        if (field[moovingTo] == 0)
                        {
                            
                            field[moovingTo] = 1;
                        }
                        else if (field[moovingTo] == 1)
                        {

                            for (int i = (field[moovingTo]); i <= int.MinValue; i += moovingTo)
                            {
                                if (field[i] >= fieldSize)
                                {
                                    field[i - moovingTo] = 0;
                                    break;
                                }
                                else
                                {
                                    if (field[i] == 0)
                                    {
                                        field[i] = 1;
                                    }
                                    else
                                    {
                                        field[i] = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
