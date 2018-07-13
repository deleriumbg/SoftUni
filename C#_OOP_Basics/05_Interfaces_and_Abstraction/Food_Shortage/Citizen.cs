public class Citizen : IIdentifiable, IBirthday, IBuyer
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
    public string Birthday { get; private set; }
    public int Food { get; private set; }

    public Citizen(string name, int age, string id, string birthday)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthday = birthday;
    }
    
    public void BuyFood()
    {
        Food += 10;
    }
}
