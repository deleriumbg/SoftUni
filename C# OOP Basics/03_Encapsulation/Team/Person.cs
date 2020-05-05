using System;

public class Person
{
    private const decimal MIN_SALARY = 460;
    private const int MIN_NAME_LENGTH = 3;

    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get { return firstName; }
        private set
        {
            ValidateNameLength(value, "First name");
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        private set
        {
            ValidateNameLength(value, "Last name");
            this.lastName = value;
        }
    }

    public int Age
    {
        get { return age; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            this.age = value;
        }
    }

    public decimal Salary
    {
        get { return salary; }
        private set
        {
            if (value < MIN_SALARY)
            {
                throw new ArgumentException($"Salary cannot be less than {MIN_SALARY} leva!");
            }
            this.salary = value;
        }
    }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public Person(string firstName, string lastName, int age, decimal salary) : this(firstName, lastName, age)
    {
        Salary = salary;
    }

    public void ValidateNameLength(string fieldValue, string fieldName)
    {
        if (fieldValue?.Length < MIN_NAME_LENGTH)
        {
            throw new ArgumentException($"{fieldName} cannot contain fewer than {MIN_NAME_LENGTH} symbols!");
        }
    }
}
