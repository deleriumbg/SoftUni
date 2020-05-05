public class Citizen : IResident, IPerson
{
    public string Name { get; private set; }

    public string Country { get; private set; }

    public int Age { get; private set; }

    public Citizen(string name, string country, int age)
    {
        this.Name = name;
        this.Country = country;
        this.Age = age;
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.Name}";
    }

    string IPerson.GetName()
    {
        return this.Name;
    }
}
