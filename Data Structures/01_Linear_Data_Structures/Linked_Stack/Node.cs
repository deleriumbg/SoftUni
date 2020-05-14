public class Node<T>
{
    public Node(T value, Node<T> nextNode = null) 
    {
        this.Value = value;
        this.NextNode = nextNode;
    }

    public T Value { get; }

    public Node<T> NextNode { get; }
}

