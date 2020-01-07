using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int salary = int.Parse(Console.ReadLine());

            string result = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string web = Console.ReadLine();

                switch (web)
                {
                    case "Facebook":
                        salary -= 150;
                        break;
                    case "Instagram":
                        salary -= 100;
                        break;
                    case "Reddit":
                        salary -= 50;
                        break;
                }

                if (salary <= 0)
                {
                    result = "You have lost your salary.";
                    break;
                }
            }

            if (salary > 0)
            {
                result = $"{salary}";
            }

            Console.WriteLine(result);
        }
    }
}
