using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ArrayStack<T> : IEnumerable<T>
{ 
    private const int InitialCapacity = 16;

    private T[] elements;

    public int Count { get; private set; }

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }

    public void Push(T element) 
    {
        if (this.Count == this.elements.Length)
        {
            this.Grow();
        }

        this.elements[this.Count++] = element;
    }

    public T Pop() 
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        this.Count--;
        var removedElement = this.elements[this.Count];
        this.elements[this.Count] = default(T);

        return removedElement;
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return this.elements[this.Count - 1];
    }

    public T[] ToArray() 
    {
        return this.elements
        .Take(this.Count)
        .Reverse()
        .ToArray();
    }

    private void Grow() 
    {
        var newElements = new T[this.Count * 2];
        Array.Copy(this.elements, newElements, this.Count);
        this.elements = newElements;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}