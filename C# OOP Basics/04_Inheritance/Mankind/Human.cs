using System;

public class Human
{
    private const int MIN_FIRSTNAME_LENGTH = 4;
    private const int MIN_LASTNAME_LENGTH = 3;
    private string firstName;
    private string lastName;

    protected string FirstName
    {
        get { return firstName; }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(firstName)}");
            }

            if (value.Length < MIN_FIRSTNAME_LENGTH)
            {
                throw new ArgumentException($"Expected length at least {MIN_FIRSTNAME_LENGTH} symbols! Argument: {nameof(firstName)}");
            }
            firstName = value;
        }
    }

    protected string LastName
    {
        get { return lastName; }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameof(lastName)}");
            }

            if (value.Length < MIN_LASTNAME_LENGTH)
            {
                throw new ArgumentException($"Expected length at least {MIN_LASTNAME_LENGTH} symbols! Argument: {nameof(lastName)}");
            }
            lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}\r\nLast Name: {this.LastName}";
    }
}
