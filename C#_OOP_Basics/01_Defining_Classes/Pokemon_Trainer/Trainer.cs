using System.Collections.Generic;

public class Trainer
{
    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Trainer(string name, int badges, List<Pokemon> pokemons)
    {
        Name = name;
        Badges = badges;
        Pokemons = new List<Pokemon>();
    }
}
