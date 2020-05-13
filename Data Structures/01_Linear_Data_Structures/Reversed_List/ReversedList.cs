using System;
using System.Collections;
using System.Collections.Generic;

public class ReversedList<T> : IEnumerable<T>
{
    private const int InitialCapacity = 2;
    private const int IncreaseCapacityMultiplyer = 2;
    private T[] collection;

    public ReversedList(int capacity = InitialCapacity)
    {
        this.collection = new T[capacity];
    }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            ValidateIndexInput(index);
            return this.collection[this.ReversedIndex(index)];
        }

        set
        {
            ValidateIndexInput(index);
            this.collection[this.ReversedIndex(index)] = value;
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
        T itemToRemove = this[index];
        this[index] = default;
        this.ShiftLeft(this.ReversedIndex(index));
        this.Count--;

        return itemToRemove;
    }

    private void ShiftLeft(int index)
    {
        for (int i = index; i < this.Count - 1; i++)
        {
            this.collection[i] = this.collection[i + 1];
        }

        this.collection[this.Count - 1] = default(T);
    }

    private int ReversedIndex(int index) => this.Count - 1 - index;

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
