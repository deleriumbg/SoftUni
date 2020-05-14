using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedQueue<T> : IEnumerable<T>
{
    private QueueNode<T> head;
    private QueueNode<T> tail;
    public int Count { get; private set; }

    public void Enqueue(T element) 
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new QueueNode<T>(element);
        }
        else
        {
            var newHead = new QueueNode<T>(element);
            newHead.NextNode = this.head;

            this.head.PrevNode = newHead;
            this.head = newHead;
        }

        this.Count++;
    }

    public T Dequeue() 
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Queue empty");
        }

        this.Count--;
        var removedElement = this.tail.Value;

        this.tail = this.tail.PrevNode;
        if (this.tail == null)
        {
            this.head = null;
        }
        else
        {
            this.tail.NextNode = null;
        }

        return removedElement;
    }

    public T[] ToArray() 
    {
        var arr = new T[this.Count];
        var current = this.head;
        var index = this.Count - 1;

        while (index >= 0)
        {
            arr[index--] = current.Value;
            current = current.NextNode;
        }

        return arr;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;
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

