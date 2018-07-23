using System;

public class Person : IComparable<Person>
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }
        return result;
    }

    public override bool Equals(object obj)
    {
        if (obj is Person other)
        {
            return this.Name == other.Name && this.Age == other.Age;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() + this.Age.GetHashCode();
    }
}
