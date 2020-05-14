using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedStack<T> : IEnumerable<T>
{
    private Node<T> top;

    public int Count { get; private set; }

    public void Push(T element)
    {
        this.top = new Node<T>(element, this.top);
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        var removedElement = this.top.Value;
        this.top = this.top.NextNode;
        this.Count--;
        return removedElement;
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return this.top.Value;
    }


    public T[] ToArray() 
    {
        var arr = new T[this.Count];
        var currentNode = this.top;
        var index = 0;

        while (currentNode != null)
        {
            arr[index++] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return arr;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.top;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

