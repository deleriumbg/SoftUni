using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private readonly List<T> sequence;

    public Box(List<T> sequence)
    {
        this.sequence = sequence;
    }

    public void Swap(int first, int second)
    {
        T temp = sequence[first];
        sequence[first] = sequence[second];
        sequence[second] = temp;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        foreach (var item in sequence)
        {
            result.AppendLine($"{typeof(T).FullName}: {item}");
        }

        return result.ToString().TrimEnd();
    }
}
