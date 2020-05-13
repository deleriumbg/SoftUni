using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private Node<T> head;
    private Node<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new Node<T>(item);
        }
        else
        {
            var newHead = new Node<T>(item);
            newHead.Next = this.head;
            this.head = newHead;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new Node<T>(item);
        }
        else
        {
            var newTail = new Node<T>(item);
            this.tail.Next = newTail;
            this.tail = newTail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var itemToRemove = this.head.Value;
        this.head = this.head.Next;
        this.Count--;
        return itemToRemove;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var itemToRemove = this.tail.Value;
        this.Count--;

        if (this.Count == 0)
        {
            this.head = this.tail = null;
        }
        else
        {
            var newTail = this.GetSecondToLast();
            newTail.Next = null;
            this.tail = newTail;
        }

        return itemToRemove;
    }

    private Node<T> GetSecondToLast()
    {
        var secondToLast = this.head;
        for (int i = 0; i < this.Count - 1; i++)
        {
            secondToLast = secondToLast.Next;
        }

        return secondToLast;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}