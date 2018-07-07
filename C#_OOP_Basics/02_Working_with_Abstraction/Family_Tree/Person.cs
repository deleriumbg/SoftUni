using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public string Birthday { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public Person()
    {
        Children = new List<Person>();
        Parents = new List<Person>();
    }
    public static Person CreatePerson(string personInput)
    {
        Person person = new Person();

        if (IsBirthday(personInput))
        {
            person.Birthday = personInput;
        }
        else
        {
            person.Name = personInput;
        }

        return person;
    }

    private static bool IsBirthday(string input)
    {
        return Char.IsDigit(input[0]);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}
