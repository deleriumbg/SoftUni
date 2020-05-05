using System;
using System.Collections.Generic;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                persons.Add(person);
            }

            decimal bonus = decimal.Parse(Console.ReadLine());
            persons.ForEach(p =>
            {
                p.IncreaseSalary(bonus);
                Console.WriteLine(p.ToString());
            });
        }
    }
}
