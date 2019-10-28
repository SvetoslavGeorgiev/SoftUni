using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minIncome = double.Parse(Console.ReadLine());

            double socialScholarship = minIncome * 0.35;
            double ExcellentScholorship = 25 * grade;
            
            

            if (income < minIncome && grade > 4.50 && grade < 5.50)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }
            else if (income < minIncome && grade >= 5.50)
            {
                if (socialScholarship > ExcellentScholorship)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(ExcellentScholorship)} BGN");
                }
            }
            else if (income >= minIncome && grade >= 5.50)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(ExcellentScholorship)} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
