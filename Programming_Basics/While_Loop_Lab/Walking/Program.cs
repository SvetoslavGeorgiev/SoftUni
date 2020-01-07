using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int allsteps = 0;


            while (true)
            {
                if (command == "Going home")
                {
                    int homeSteps = int.Parse(Console.ReadLine());
                    allsteps += homeSteps;
                    break;
                }
                int steps = int.Parse(command);
                allsteps += steps;
                if (allsteps >= 10000)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            if (allsteps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                int stepsNeeded = 10000 - allsteps;
                Console.WriteLine($"{stepsNeeded} more steps to reach goal.");
            }
        }
    }
}
