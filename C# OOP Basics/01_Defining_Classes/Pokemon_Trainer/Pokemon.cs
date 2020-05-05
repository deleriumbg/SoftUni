public class Pokemon
{
    public string Name { get; set; }
    public string Element { get; set; }
    public double Health { get; set; }

    public Pokemon(string name, string element, double health)
    {
        Name = name;
        Element = element;
        Health = health;
    }
}
