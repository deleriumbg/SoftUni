public class Parent
{
    public string Name { get; set; }
    public string Birthday { get; set; }

    public Parent(string name, string birthday)
    {
        Name = name;
        Birthday = birthday;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}
