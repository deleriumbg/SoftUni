using System;
using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private readonly List<int> collection;

    public Lake(List<int> collection)
    {
        this.collection = collection;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.collection.Count; i++)
        {
            if (i % 2 == 0)
            {
                yield return this.collection[i];
            }
        }

        for (int i = this.collection.Count - 1; i >= 0; i--)
        {
            if (i % 2 != 0)
            {
                yield return this.collection[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
