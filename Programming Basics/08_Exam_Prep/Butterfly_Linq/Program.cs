using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine()) - 2;
        var wings = Enumerable.Range(0, n)
        .Select(a => string.Format(@"{0}\ /{0}", new string(a % 2 == 0 ? '*' : '-', n)));
        var reversed = wings.Select(a => new string(a.Reverse().ToArray()));
        var butterfly = wings.Concat(new[] { string.Format("{0}@{0}", new string(' ', n + 1)) }).Concat(reversed);
        Console.WriteLine(string.Join(Environment.NewLine, butterfly));
    }
}
