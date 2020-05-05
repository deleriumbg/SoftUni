using System;

namespace Retirement
{
    class Program
    {
        static void Main(string[] args)
        {
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int yearsWorked = int.Parse(Console.ReadLine());

            switch (gender)
            {
                case "male":
                    if (age < 1)
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    else if (age >= 64)
                    {
                        if (yearsWorked < 1)
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        else if (yearsWorked >= 38)
                        {
                            Console.WriteLine($"Ready to retire at {age} and {yearsWorked} years of experience!");
                        }
                        else
                        {
                            Console.WriteLine($"Old enough, but haven't worked enough. Work experience left to retirement: {38 - yearsWorked}.");
                        }
                    }
                    else
                    {
                        if (yearsWorked < 1)
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        else if (yearsWorked >= 38)
                        {
                            Console.WriteLine($"Worked enough, but not old enough. Years left to retirement: {64 - age}.");
                        }
                        else
                        {
                            Console.WriteLine($"Too early. Years left to retirement: {64 - age}. Work experience left to retirement: {38 - yearsWorked}.");
                        }
                    }
                    break;
                case "female":
                    if (age < 1)
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    else if (age >= 61)
                    {
                        if (yearsWorked < 1)
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        else if (yearsWorked >= 35)
                        {
                            Console.WriteLine($"Ready to retire at {age} and {yearsWorked} years of experience!");
                        }
                        else
                        {
                            Console.WriteLine($"Old enough, but haven't worked enough. Work experience left to retirement: {35 - yearsWorked}");
                        }
                    }
                    else
                    {
                        if (yearsWorked < 1)
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        else if (yearsWorked >= 35)
                        {
                            Console.WriteLine($"Worked enough, but not old enough. Years left to retirement: {61 - age}.");
                        }
                        else
                        {
                            Console.WriteLine($"Too early. Years left to retirement: {61 - age}. Work experience left to retirement: {35 - yearsWorked}.");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }
}
