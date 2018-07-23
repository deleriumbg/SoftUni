using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
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

    public void PrintAll()
    {
        foreach (var element in collection)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.collection.Count; i++)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
