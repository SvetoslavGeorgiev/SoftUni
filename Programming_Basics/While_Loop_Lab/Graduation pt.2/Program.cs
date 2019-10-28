using System;

namespace Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string student = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());

            int currentClass = 1;
            double sameCurrentClass = 0;

            double allGrades = 0;

            while (currentClass <= 12)
            {
                if (grade >= 4.00)
                {
                    allGrades += grade;
                    currentClass++;
                    if (currentClass <= 12)
                    {
                        grade = double.Parse(Console.ReadLine());
                    }
                    else if (true)
                    {
                        double averageGrade = allGrades / 12;

                        Console.WriteLine($"{student} graduated." +
                            $" Average grade: {averageGrade:F2}");
                        break;
                    }
                }
                else if (grade < 4.00)
                {
                    sameCurrentClass++;
                    if (sameCurrentClass <= 1)
                    {
                        grade = double.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine($"{student} has been excluded at" +
                            $" {currentClass} grade");
                        break;
                    }
                }
               
            }
            
        }
    }
}
