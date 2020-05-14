public class QueueNode<T>
{
    public QueueNode(T value)
    {
        this.Value = value;
    }

    public T Value { get; private set; }

    public QueueNode<T> NextNode { get; set; }

    public QueueNode<T> PrevNode { get; set; }
}

