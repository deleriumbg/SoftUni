using System;

public abstract class Animal : ISoundProducable
{
    public const string ERROR_MESSAGE = "Invalid input!";
    private string name;
    private int age;
    private string gender;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ERROR_MESSAGE);
            }
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(ERROR_MESSAGE);
            }

            age = value;
        }
    }

    public string Gender
    {
        get { return gender; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ERROR_MESSAGE);
            }
            gender = value;
        }
    }

    protected Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public virtual void ProduceSound()
    {
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}\r\n{this.Name} {this.Age} {this.Gender}";
    }
}
