using System;

namespace Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            short age = short.Parse(Console.ReadLine());
            char sex = char.Parse(Console.ReadLine());
            long id = long.Parse(Console.ReadLine());
            uint employeeNum = uint.Parse(Console.ReadLine());
            Console.WriteLine($"First name: {firstName}\r\nLast name: {lastName}\r\nAge: {age}\r\nGender: {sex}\r\nPersonal ID: {id}\r\nUnique Employee number: {employeeNum}");
        }
    }
}
