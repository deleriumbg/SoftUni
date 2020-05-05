using System;

namespace Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int id = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}\r\nAge: {age}\r\nEmployee ID: {id:d8}\r\nSalary: {salary:f2}");
        }
    }
}
