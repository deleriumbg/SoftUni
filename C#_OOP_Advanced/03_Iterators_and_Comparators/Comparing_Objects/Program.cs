using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        string[] input = Console.ReadLine().Split();

        while (input[0] != "END")
        {
            Person person = new Person(input[0], int.Parse(input[1]), input[2]);
            people.Add(person);
            input = Console.ReadLine().Split();
        }
        int personToCompareIndex = int.Parse(Console.ReadLine());
        Person personToCompare = people[personToCompareIndex - 1];

        int numberOfEqual = 0;
        foreach (var person in people)
        {
            if (person.CompareTo(personToCompare) == 0)
            {
                numberOfEqual++;
            }
        }

        Console.WriteLine(numberOfEqual == 1
            ? "No matches"
            : $"{numberOfEqual} {people.Count - numberOfEqual} {people.Count}");
    }
}
