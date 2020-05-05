using System;

public class Child : Person
{
    private const int MAX_CHILD_AGE = 15;
    public Child(string name, int age) : base(name, age)
    {
    }

    public override int Age
    {
        get
        {
            return base.Age;
        }

        set
        {
            if (value > MAX_CHILD_AGE)
            {
                throw new ArgumentException($"Child's age must be less than {MAX_CHILD_AGE}!");
            }
            base.Age = value;
        }
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}
