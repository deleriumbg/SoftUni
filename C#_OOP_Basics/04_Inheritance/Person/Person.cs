using System;

public class Person
{
    private const int MIN_NAME_LENGTH = 3;
    private string name;
    private int age;

    protected string Name
    {
        get { return name; }
        set
        {
            if (value.Length < MIN_NAME_LENGTH)
            {
                throw new ArgumentException($"Name's length should not be less than {MIN_NAME_LENGTH} symbols!");
            }
            name = value;
        }
    }

    public virtual int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}

