public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get { return firstName; }
    }

    public string LastName
    {
        get { return lastName; }
    }

    public int Age
    {
        get { return age; }
    }

    public decimal Salary
    {
        get { return salary; }
    }

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public Person(string firstName, string lastName, int age, decimal salary) : this(firstName, lastName, age)
    {
        this.salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (Age > 30)
        {
            salary += salary * percentage / 100;
        }
        else
        {
            salary += salary * percentage / 200;
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} receives {Salary:f2} leva.";
    }
}
