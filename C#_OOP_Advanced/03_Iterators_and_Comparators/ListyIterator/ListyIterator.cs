using System;
using System.Collections.Generic;

public class ListyIterator<T>
{
    private readonly List<T> collection;
    private int internalIndex;

    public ListyIterator(List<T> collection)
    {
        this.collection = collection;
    }

    public bool Move()
    {
        if (internalIndex < this.collection.Count - 1)
        {
            internalIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return internalIndex + 1 < this.collection.Count;
    }

    public void Print()
    {
        if (this.collection == null || internalIndex >= this.collection.Count)
        {
            throw new ArgumentException("Invalid Operation!");
        }
        Console.WriteLine(this.collection[internalIndex]);
    }
}
