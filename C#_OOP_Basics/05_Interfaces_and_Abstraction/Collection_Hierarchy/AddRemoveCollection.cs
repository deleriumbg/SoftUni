using System.Collections.Generic;
using System.Linq;

public class AddRemoveCollection : IAdd, IRemove
{
    private List<string> data;

    public AddRemoveCollection()
    {
        this.data = new List<string>();
    }

    public int Add(string element)
    {
        this.data.Insert(0, element);

        return 0;
    }

    public string Remove()
    {
        string element = this.data.Last();
        this.data.RemoveAt(this.data.Count - 1);
        return element;
    }
}
