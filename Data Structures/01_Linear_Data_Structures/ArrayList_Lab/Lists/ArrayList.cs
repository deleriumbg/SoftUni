using System;
using System.Collections;
using System.Collections.Generic;

public class ArrayList<T> : IEnumerable<T>
{
    private const int InitialCapacity = 2;
    private const int IncreaseCapacityMultiplyer = 2;
    private const int DecreaseCapacityMultiplyer = 3;
    private T[] collection;

    public ArrayList(int capacity = InitialCapacity)
    {
        this.collection = new T[capacity];
    }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            ValidateIndexInput(index);
            return this.collection[index];
        }

        set
        {
            ValidateIndexInput(index);
            this.collection[index] = value;
        }
    }

    private void ValidateIndexInput(int index)
    {
        if (index < 0 || index > this.collection.Length)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void Add(T item)
    {
        if (this.Count >= this.collection.Length)
        {
            this.ResizeCollection(this.collection.Length * IncreaseCapacityMultiplyer);
        }
        this.collection[this.Count++] = item;
    }

    private void ResizeCollection(int size)
    {
        T[] newCollection = new T[size];
        Array.Copy(this.collection, newCollection, this.Count);
        this.collection = newCollection;
    }

    public T RemoveAt(int index)
    {
        this.ValidateIndexInput(index);
        T itemToRemove = this.collection[index];
        this.collection[index] = default;
        this.Count--;
        this.ShiftLeft(index);

        if (this.Count <= this.collection.Length / DecreaseCapacityMultiplyer)
        {
            this.ResizeCollection(this.collection.Length / DecreaseCapacityMultiplyer);
        }
        return itemToRemove;
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < this.Count; i++)
        {
            this.collection[i] = this.collection[i + 1];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in this.collection)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
