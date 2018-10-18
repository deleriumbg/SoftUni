using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static List<Person> people;
    private static List<string> relationships;

    static void Main(string[] args)
    {
        string mainPersonInput = Console.ReadLine();
        string input = Console.ReadLine();
        people = new List<Person>();
        relationships = new List<string>();

        while (input != "End")
        {
            if (!input.Contains("-"))
            {
                string[] inputArgs = input.Split();
                string fullName = $"{inputArgs[0]} {inputArgs[1]}";
                string birthday = inputArgs[2];
                people.Add(new Person(fullName, birthday));
            }
            else
            {
                relationships.Add(input);
            }

            input = Console.ReadLine();
        }

        foreach (var entry in relationships)
        {
            string[] parentChild = entry.Split(" - ");
            Person parent = GetPerson(parentChild[0]);
            Person child = GetPerson(parentChild[1]);

            parent.Children.Add(child);
            child.Parents.Add(parent);
        }

        Person mainPerson = GetPerson(mainPersonInput);
        Console.WriteLine($"{mainPerson.FullName} {mainPerson.Birthday}");
        Console.WriteLine("Parents:");
        foreach (var parent in mainPerson.Parents)
        {
            Console.WriteLine($"{parent.FullName} {parent.Birthday}");
        }

        Console.WriteLine("Children:");
        foreach (var child in mainPerson.Children)
        {
            Console.WriteLine($"{child.FullName} {child.Birthday}");
        }
    }

    private static Person GetPerson(string input)
    {
        return input.Contains("/") ? people.FirstOrDefault(x => x.Birthday == input) : 
            people.FirstOrDefault(x => x.FullName == input);
    }
}