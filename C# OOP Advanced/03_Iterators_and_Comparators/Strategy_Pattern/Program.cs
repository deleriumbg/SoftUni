using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> names = new SortedSet<Person>(new NameComparator());
        SortedSet<Person> ages = new SortedSet<Person>(new AgeComparator());

        int numberOfPeople = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] personInput = Console.ReadLine().Split();
            Person person = new Person(personInput[0], int.Parse(personInput[1]));
            names.Add(person);
            ages.Add(person);
        }

        foreach (var person in names)
        {
            Console.WriteLine(person);
        }

        foreach (var person in ages)
        {
            Console.WriteLine(person);
        }
    }
}
