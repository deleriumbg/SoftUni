using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int employeeCount = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();
        List<Department> departments = new List<Department>();

        for (int i = 0; i < employeeCount; i++)
        {
            string[] employeeInfo = Console.ReadLine().Split();
            string name = employeeInfo[0];
            decimal salary = decimal.Parse(employeeInfo[1]);
            string position = employeeInfo[2];
            string departmentName = employeeInfo[3];
            string email = "n/a";
            int age = -1;

            switch (employeeInfo.Length)
            {
                case 6:
                {
                    email = employeeInfo[4];
                    age = int.Parse(employeeInfo[5]);
                    break;
                }
                case 5:
                {
                    bool isAge = int.TryParse(employeeInfo[4], out age);
                    if (!isAge)
                    {
                        email = employeeInfo[4];
                        age = -1;
                    }
                    break;
                }
            }

            Employee employee = new Employee(name, salary, position, departmentName, email, age);
            employees.Add(employee);
            if (departments.All(x => x.Name != departmentName))
            {
                Department department = new Department(departmentName, new List<decimal>());
                department.Salaries.Add(salary);
                departments.Add(department);
            }
            else
            {
                Department existingDepartment = departments.First(x => x.Name == departmentName);
                existingDepartment.Salaries.Add(salary);
            }         
        }

        var highestPaidDepartment = departments.OrderByDescending(x => x.Salaries.Average()).First();
        Console.WriteLine($"Highest Average Salary: {highestPaidDepartment.Name}");
        foreach (var employee in employees.Where(x => x.Department == highestPaidDepartment.Name).OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}
