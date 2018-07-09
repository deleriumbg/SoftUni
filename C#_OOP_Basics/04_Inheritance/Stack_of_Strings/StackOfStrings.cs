using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> data = new List<string>();

    public bool IsEmpty()
    {
        return data.Count == 0;
    }

    public void Push(string item)
    {
        data.Add(item);
    }

    public string Peek()
    {
        return data.Last();
    }

    public string Pop()
    {
        string result = null;
        if (!IsEmpty())
        {
            result = data.Last();
            data.RemoveAt(data.Count - 1);
        }
        return result;
    }
}
