using System.Collections.Generic;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);

        foreach (var child in this.Children)
        {
            child.Parent = this;
        }
    }

    public T Value { get; }

    public Tree<T> Parent { get; set; }

    public IList<Tree<T>> Children { get; set; }

}