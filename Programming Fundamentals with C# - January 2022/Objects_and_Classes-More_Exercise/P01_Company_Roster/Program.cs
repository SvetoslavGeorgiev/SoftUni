using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var employeeList = new List<Employee>();

            var numbersOfInput = int.Parse(Console.ReadLine());
            

            var listOfDepartments = new List<string>();

            for (int i = 0; i < numbersOfInput; i++)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var currentEmployee = command[0];
                var currentEmployeeSalary = decimal.Parse(command[1]);
                var currentEmployeeDepartment = command[2];

                var employee = new Employee(currentEmployee, currentEmployeeSalary, currentEmployeeDepartment);

                employeeList.Add(employee);

                if (!listOfDepartments.Contains(currentEmployeeDepartment))
                {
                    listOfDepartments.Add(currentEmployeeDepartment);
                }
            }
            var highestAvgSalaryOfTheDepartmets = 0.00m;
            var departmentWithHighAvgSalary = string.Empty;

            foreach (var department in listOfDepartments)
            {
                var currentHighestSalary = 0.00m;
                
                var employeeOfTheDepartmentTotalSalary = 0.00m;
                var employeeInTheDepartment = 0;
                foreach (var employee in employeeList)
                {
                    if (employee.Department == department)
                    {
                        employeeOfTheDepartmentTotalSalary += employee.Salary;
                        employeeInTheDepartment++;
                    }
                }
                currentHighestSalary = employeeOfTheDepartmentTotalSalary / employeeInTheDepartment;

                if (currentHighestSalary > highestAvgSalaryOfTheDepartmets)
                {
                    highestAvgSalaryOfTheDepartmets = currentHighestSalary;
                    departmentWithHighAvgSalary = department;
                }
            }
            var extractedListOfEmployeesFromTheDepartmentWithHighestSalary = employeeList.Where(e => e.Department == departmentWithHighAvgSalary)
                .OrderByDescending(e => e.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {departmentWithHighAvgSalary}");
            extractedListOfEmployeesFromTheDepartmentWithHighestSalary.ForEach(e => Console.WriteLine($"{e.Name} {e.Salary:F2}"));

        }
    }

    public class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }

}
