using System;

public class Sorter<T> where T : IComparable<T>
{
    public static void Sort(CustomList<T> customList)
    {
        customList.Sort();
    }
}
