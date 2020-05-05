using System;
using System.Collections;
using System.Collections.Generic;

public class CustomStack<T> : IEnumerable<T>
{
    private readonly List<T> collection;

    public CustomStack()
    {
        this.collection = new List<T>();
    }

    public void Push(params T[] elements)
    {
        this.collection.AddRange(elements);
    }

    public void Pop()
    {
        if (this.collection.Count == 0)
        {
            throw new ArgumentException("No elements");
        }
        this.collection.RemoveAt(this.collection.Count - 1);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.collection.Count - 1; i >= 0; i--)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
