using System.Collections.Generic;

public class Team
{
    private const int AGE_SEPARATION = 40;
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return this.firstTeam; }
    }
    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return this.reserveTeam; }
    }

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public void AddPlayer(Person player)
    {
        if (player.Age < AGE_SEPARATION)
        {
            firstTeam.Add(player);
        }
        else
        {
            reserveTeam.Add(player);
        }
    }
}
