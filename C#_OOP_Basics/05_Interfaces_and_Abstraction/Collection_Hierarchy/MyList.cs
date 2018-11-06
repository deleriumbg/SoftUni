using System.Collections.Generic;

public class MyList : IAdd, IRemove, ICountable
{
    private List<string> data;

    public MyList()
    {
        this.data = new List<string>();
    }
    public int Used => this.data.Count;

    public int Add(string element)
    {
        this.data.Insert(0, element);

        return 0;
    }

    public string Remove()
    {
        string element = this.data[0];
        this.data.RemoveAt(0);
        return element;
    }
}
