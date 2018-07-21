using System;

class Program
{
    static void Main(string[] args)
    {
        CustomList<string> customList = new CustomList<string>();
        string[] input = Console.ReadLine().Split();
        while (input[0] != "END")
        {
            switch (input[0])
            {
                case "Add":
                    string elementToAdd = input[1];
                    customList.Add(elementToAdd);
                    break;
                case "Remove":
                    int indexToRemove = int.Parse(input[1]);
                    customList.Remove(indexToRemove);
                    break;
                case "Contains":
                    string elementContained = input[1];
                    Console.WriteLine(customList.Contains(elementContained));
                    break;
                case "Swap":
                    int firstIndex = int.Parse(input[1]);
                    int secondIndex = int.Parse(input[2]);
                    customList.Swap(firstIndex, secondIndex);
                    break;
                case "Greater":
                    string greaterElement = input[1];
                    Console.WriteLine(customList.CountGreaterThan(greaterElement));
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());
                    break;
                case "Print":
                    for (int i = 0; i < customList.Count; i++)
                    {
                        Console.WriteLine(customList[i]);
                    }
                    break;
            }
            input = Console.ReadLine().Split();
        }
    }
}