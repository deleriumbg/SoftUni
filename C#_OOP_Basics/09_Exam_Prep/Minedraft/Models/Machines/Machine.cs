public abstract class Machine
{
    public string Id { get; protected set; }

    protected Machine(string id)
    {
        this.Id = id;
    }
}
