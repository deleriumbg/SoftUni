using System;

class Program
{
    static void Main(string[] args)
    {
        Scale<int> scale = new Scale<int>(4, 2);
        Console.WriteLine(scale.GetHeavier());
    }
}
