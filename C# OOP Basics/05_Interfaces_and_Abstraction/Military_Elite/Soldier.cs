public abstract class Soldier : ISoldier
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }

    protected Soldier(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} ";
    }
}
