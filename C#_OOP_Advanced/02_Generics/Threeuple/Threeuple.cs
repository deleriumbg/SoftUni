public class Threeuple<T1, T2, T3>
{
    public T1 Item1 { get; private set; }
    public T2 Item2 { get; private set; }
    public T3 Item3 { get; private set; }

    public Threeuple(T1 item1, T2 item2, T3 item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
    }

    public override string ToString()
    {
        return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
    }
}
