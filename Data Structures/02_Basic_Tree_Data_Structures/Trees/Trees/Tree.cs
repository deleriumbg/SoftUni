using System;
using System.Collections.Generic;
using System.Linq;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
    }

    public T Value { get; }

    public IList<Tree<T>> Children { get; }

    public void Print(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', 2 * indent)}{this.Value}");
        foreach (var child in this.Children)
        {
            child.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);

        foreach (var child in this.Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        var result = new List<T>();
        this.OrderDFS(this, result);
        return result;
    }

    private void OrderDFS(Tree<T> tree, List<T> result)
    {
        foreach (var child in tree.Children)
        {
            this.OrderDFS(child, result);
        }

        result.Add(tree.Value);
    }

    public IEnumerable<T> OrderBFS()
    {
        var result = new List<T>();
        var queue = new Queue<Tree<T>>();
        queue.Enqueue(this);

        while (queue.Any())
        {
            var current = queue.Dequeue();
            result.Add(current.Value);

            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }

        return result;
    }
}
