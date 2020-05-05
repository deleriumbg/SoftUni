public class Box<T>
{
    private readonly T storedValue;

    public Box(T storedValue)
    {
        this.storedValue = storedValue;
    }

    public override string ToString()
    {
        return $"{typeof(T).FullName}: {this.storedValue}";
    }
}
