using System;
using System.Collections.Generic;

public class Box<T> where T : IComparable<T>
{
    public List<T> Collection { get; private set; }
    public T Element { get; private set; }
    public int NumberOfGreaterElements { get; private set; }

    public Box(List<T> collection, T element)
    {
        Collection = collection;
        Element = element;
    }

    public int FindNumberOfGreaterElements(List<T> collection, T element)
    {
        foreach (var item in collection)
        {
            if (item.CompareTo(this.Element) > 0)
            {
                this.NumberOfGreaterElements++;
            }
        }

        return this.NumberOfGreaterElements;
    }
}
