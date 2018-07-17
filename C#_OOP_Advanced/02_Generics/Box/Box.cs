using System;
using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private List<T> sequence;

    public Box()
    {
        this.sequence = new List<T>();
    }

    public int Count => sequence.Count;

    public void Add(T element)
    {
        sequence.Add(element);
    }

    public T Remove()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        T itemToRemove = sequence.Last();
        sequence.RemoveAt(sequence.Count - 1);
        return itemToRemove;
    }
}
