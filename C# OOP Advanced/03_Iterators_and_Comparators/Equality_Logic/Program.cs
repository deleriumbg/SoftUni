using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> sortedSet = new SortedSet<Person>();
        HashSet<Person> hashSet = new HashSet<Person>();

        int numberOfPeople = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] personInput = Console.ReadLine().Split();
            Person person = new Person(personInput[0], int.Parse(personInput[1]));
            sortedSet.Add(person);
            hashSet.Add(person);
        }

        Console.WriteLine($"{sortedSet.Count}\r\n{hashSet.Count}");
    }
}

