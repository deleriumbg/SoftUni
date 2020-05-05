using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int personCount = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < personCount; i++)
        {
            string[] personInfo = Console.ReadLine().Split(' ');
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            Person person = new Person(name, age);
            people.Add(person);
        }

        foreach (var person in people.Where(x => x.Age > 30).OrderBy(x => x.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
