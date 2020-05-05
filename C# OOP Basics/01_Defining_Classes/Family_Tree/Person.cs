using System.Collections.Generic;

public class Person
{
    public string FullName { get; set; }
    public string Birthday { get; set; }
    public HashSet<Person> Parents { get; set; }
    public HashSet<Person> Children { get; set; }

    public Person(string fullName, string birthday)
    {
        this.FullName = fullName;
        this.Birthday = birthday;
        this.Parents = new HashSet<Person>();
        this.Children = new HashSet<Person>();
    }
}
