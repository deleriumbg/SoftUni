public class Pet : IBirthday
{
    public string Name { get; private set; }
    public string Birthday { get; private set; }

    public Pet(string name, string birthday)
    {
        Name = name;
        Birthday = birthday;
    }
}
