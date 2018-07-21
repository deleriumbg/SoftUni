using System;

public class CustomList<T> where T : IComparable<T>
{
    private T[] data;

    public T this[int index]
    {
        get
        {
            return this.data[index];
        }
        set
        {
            this.data[index] = value;
        }
    }

    public CustomList()
    {
        this.data = new T[4];
    }

    public int Count { get; private set; }

    public void Add(T element)
    {
        this.Count++;
        if (this.Count > this.data.Length)
        {
            T[] newData = new T[this.data.Length * 2];
            Array.Copy(this.data, newData, this.data.Length);
            this.data = newData;
        }

        this.data[this.Count - 1] = element;
    }

    public T Remove(int index)
    {
        this.Count--;
        T removedElement = this.data[index];
        if (this.Count < this.data.Length / 3)
        {
            T[] newData = new T[this.data.Length / 2];
            Array.Copy(this.data, newData, this.data.Length);
            this.data = newData;
        }

        for (int i = index; i < this.Count; i++)
        {
            this.data[i] = this.data[i + 1];
        }
        
        this.data[this.Count] = default(T);
        return removedElement;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this.data[i].Equals(element))
            {
                return true;
            }
        }
        return false;
    }

    public void Swap(int index1, int index2)
    {
        T temp = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        for (int i = 0; i < this.Count; i++)
        {
            if (this.data[i].CompareTo(element) > 0)
            {
                count++;
            }
        }
        return count;
    }

    public T Max()
    {
        T maxElement = this.data[0];
        for (int i = 1; i < this.Count; i++)
        {
            if (this.data[i].CompareTo(maxElement) > 0)
            {
                maxElement = this.data[i];
            }
        }
        return maxElement;
    }

    public T Min()
    {
        T minElement = this.data[0];
        for (int i = 1; i < this.Count; i++)
        {
            if (this.data[i].CompareTo(minElement) < 0)
            {
                minElement = this.data[i];
            }
        }
        return minElement;
    }

    public void Sort()
    {
        Array.Sort(this.data, 0, this.Count);
    }
}
