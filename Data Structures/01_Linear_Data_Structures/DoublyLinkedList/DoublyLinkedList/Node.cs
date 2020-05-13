public class ListNode<T>
{
    public ListNode(T value)
    {
        this.Value = value;
    }

    public T Value { get; set; }

    public ListNode<T> PrevNode { get; set; }

    public ListNode<T> NextNode { get; set; }
}
