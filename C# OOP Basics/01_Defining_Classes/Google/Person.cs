using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Child> Children { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Person(string name, Company company)
    {
        Name = name;
        Company = company;
    }

    public Person(string name, Car car)
    {
        Name = name;
        Car = car;
    }

    public Person(string name, List<Parent> parents)
    {
        Name = name;
        Parents = new List<Parent>();
    }

    public Person(string name, List<Child> children)
    {
        Name = name;
        Children = new List<Child>();
    }

    public Person(string name, List<Pokemon> pokemons)
    {
        Name = name;
        Pokemons = new List<Pokemon>();
    }

    public override string ToString()
    {
        var pokemons = this.Pokemons == null ? "" : $"{string.Join("\n", this.Pokemons)}";
        var parents = this.Parents == null ? "" : $"{string.Join("\n", this.Parents)}";
        var children = this.Children == null ? "" : $"{string.Join("\n", this.Children)}";
        return
            $"{this.Name}" +
            "\r\nCompany:" +
            $"\r\n{this.Company}".TrimEnd() +
            "\r\nCar:" +
            $"\r\n{this.Car}".TrimEnd() +
            "\r\nPokemon:" +
            $"\r\n{pokemons}".TrimEnd() +
            "\r\nParents:" +
            $"\r\n{parents}".TrimEnd() +
            "\r\nChildren:" +
            $"\r\n{children}".TrimEnd();
    }
}
