using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            double startSalary = double.Parse(Console.ReadLine());
            int workedYears = int.Parse(Console.ReadLine());
            string sindicat = Console.ReadLine();

            for (int i = 1; i <= 100; i++)
            {
                startSalary = startSalary * 1.06;

                if (i % 5 == 0)
                {
                    startSalary += 100;
                }
                if (i % 10 == 0)
                {
                    startSalary += 100;
                }
                if (sindicat == "Yes" && (i % 5 != 0 || i % 10 != 0))
                {
                    startSalary *= 0.99;
                }
                if (workedYears == i && startSalary < 5000)
                {
                    Console.WriteLine($"Current salary: {startSalary:f2}");
                }
                else if (workedYears >= i && startSalary >= 5000)
                {
                    startSalary = 5000;
                    Console.WriteLine($"Current salary: {startSalary:f2}");
                    Console.WriteLine($"0 more years to max salary.");
                    break;
                }

                if (startSalary >= 5000)
                {
                    int yearsToAdd = i - 1 - workedYears;
                    Console.WriteLine($"{yearsToAdd} more years to max salary.");
                    break;
                }

            }
        }
    }
}
