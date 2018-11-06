using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var addCollection = new AddCollection();
        var addRemoveCollection = new AddRemoveCollection();
        var myList = new MyList();

        string[] elements = Console.ReadLine().Split();
        int count = int.Parse(Console.ReadLine());

        List<int> addCollectionResults = new List<int>();
        List<int> addRemoveCollectionResults = new List<int>();
        List<int> myListResults = new List<int>();
        List<string> addRemoveCollectionRemoves = new List<string>();
        List<string> myListRemoves = new List<string>();

        foreach (string element in elements)
        {
            addCollectionResults.Add(addCollection.Add(element));
            addRemoveCollectionResults.Add(addRemoveCollection.Add(element));
            myListResults.Add(myList.Add(element));
        }

        for (int i = 0; i < count; i++)
        {
            addRemoveCollectionRemoves.Add(addRemoveCollection.Remove());
            myListRemoves.Add(myList.Remove());
        }

        Console.WriteLine(string.Join(" ", addCollectionResults));
        Console.WriteLine(string.Join(" ", addRemoveCollectionResults));
        Console.WriteLine(string.Join(" ", myListResults));
        Console.WriteLine(string.Join(" ", addRemoveCollectionRemoves));
        Console.WriteLine(string.Join(" ", myListRemoves));
    }
}
