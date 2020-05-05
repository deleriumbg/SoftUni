using System.Collections.Generic;

public class AddCollection : IAdd
{
    private List<string> data;

    public AddCollection()
    {
        this.data = new List<string>();
    }

    public int Add(string element)
    {
        this.data.Add(element);

        return this.data.LastIndexOf(element);
    }
}
