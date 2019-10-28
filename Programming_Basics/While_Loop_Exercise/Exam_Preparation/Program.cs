using System;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLowerGrades = int.Parse(Console.ReadLine());
            string problemName = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            string stopByTheLector = "Enough";
            int counterForLowerGrades = 0;
            int counterForGrades = 0;
            double sumOfAllGrades = 0;
            double averadgeGrade = 0;
            bool stop = false;
            string lastProblem = string.Empty;

            while (counterForLowerGrades <= numberOfLowerGrades)
            {
                if (stopByTheLector == problemName)
                {
                    stop = true;
                    averadgeGrade = sumOfAllGrades / counterForGrades;
                    break;
                }
                lastProblem = problemName;
                if (grade <= 4.00)
                {
                    counterForLowerGrades++;
                }
                if (numberOfLowerGrades == counterForLowerGrades)
                {
                    Console.WriteLine($"You need a break, {numberOfLowerGrades} poor grades.");
                    break;
                }
                sumOfAllGrades += grade;
                counterForGrades++;
                problemName = Console.ReadLine();
                if (stopByTheLector != problemName)
                {
                    grade = double.Parse(Console.ReadLine());
                }
            }
            if (stop == true)
            {
                Console.WriteLine($"Average score: {averadgeGrade:F2}");
                Console.WriteLine($"Number of problems: {counterForGrades}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }

    }
}