using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            List<int> listOfPassangers = command.Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            var command2 = Console.ReadLine();

            while (command2 != "end")
            {
                if (command2.StartsWith("Add"))
                {
                   var temp = command2.Split().ToList();

                    int temp2 = int.Parse(temp[1]);
                    if (temp2 <= maxCapacity)
                    {
                        listOfPassangers.Add(temp2);
                    }
                }
                else
                {
                    var temp = int.Parse(command2);

                    for (int i = 0; i < listOfPassangers.Count; i++)
                    {
                        if (listOfPassangers[i] + temp <= maxCapacity)
                        {
                            listOfPassangers[i] += temp;
                            break;
                        }
                        //break;
                    }
                }

                command2 = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", listOfPassangers));


        }
    }
}
