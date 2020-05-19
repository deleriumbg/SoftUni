using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node<T> root;

    public BinarySearchTree()
    {
        this.root = null;
    }

    private BinarySearchTree(Node<T> node) : this()
    {
        this.Copy(node);
    }

    public void Insert(T value)
    {
        if (this.root == null)
        {
            this.root = new Node<T>(value);
            return;
        }

        Node<T> parent = null;
        Node<T> current = this.root;

        while (current != null)
        {
            var compare = value.CompareTo(current.Value);
            if (compare == 0)
            {
                break;
            }

            parent = current;
            if (compare < 0)
            {
                current = current.Left;
            }
            else if (compare > 0)
            {
                current = current.Right;
            }
        }

        var newNode = new Node<T>(value);
        if (value.CompareTo(parent.Value) < 0)
        {
            parent.Left = newNode;
        }
        else
        {
            parent.Right = newNode;
        }
    }

    public bool Contains(T value)
    {
        var node = this.FindNode(value);
        return node != null;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        Node<T> parent = null;
        Node<T> min = this.root;

        while (min.Left != null)
        {
            parent = min;
            min = min.Left;
        }

        if (parent == null)
        {
            this.root = min.Right;
        }
        else
        {
            parent.Left = min.Right;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        var node = this.FindNode(item);
        return node != null
            ? new BinarySearchTree<T>(node)
            : null;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();
        this.Range(this.root, queue, startRange, endRange);
        return queue;
    }

    private void Range(Node<T> node, Queue<T> result, T start, T end)
    {
        if (node == null)
        {
            return;
        }

        var compareStart = node.Value.CompareTo(start);
        var compareEnd = node.Value.CompareTo(end);

        // start < node 
        if (compareStart > 0)         {
            this.Range(node.Left, result, start, end);
        }

        // in range
        if (compareStart >= 0 && compareEnd <= 0) 
        {
            result.Enqueue(node.Value);
        }

        // node < end 
        if (compareEnd < 0) 
        {
            this.Range(node.Right, result, start, end);
        }
    }

    public void EachInOrder(Action<T> action) => this.EachInOrder(action, this.root);

    private void EachInOrder(Action<T> action, Node<T> node)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(action, node.Left);
        action(node.Value);
        this.EachInOrder(action, node.Right);
    }

    private Node<T> FindNode(T value)
    {
        var current = this.root;

        while (current != null)
        {
            var compare = value.CompareTo(current.Value);
            if (compare == 0)
            {
                break;
            }

            if (compare < 0)
            {
                current = current.Left;
            }
            else if (compare > 0)
            {
                current = current.Right;
            }
        }

        return current;
    }

    private void Copy(Node<T> node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }
}