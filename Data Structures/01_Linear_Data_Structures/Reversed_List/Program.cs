using System;

public class Program
{
    public static void Main(string[] args)
    {
        var reversedList = new ReversedList<int>();

        reversedList.Add(1);
        reversedList.Add(2);
        reversedList.Add(3);
        reversedList.Add(-4);

        Console.WriteLine(reversedList[0]);
        reversedList[0] *= -1;
        Console.WriteLine(reversedList[0]);

        Print(reversedList);

        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Removed: {reversedList.RemoveAt(reversedList.Count - 1)}");
            Print(reversedList);

            Console.WriteLine($"Removed: {reversedList.RemoveAt(0)}");
            Print(reversedList);
        }
    }

    private static void Print(ReversedList<int> reversedList)
    {
        Console.WriteLine($"Count: {reversedList.Count}");

        foreach (var item in reversedList)
        {
            Console.WriteLine(item);
        }
    }
}