using System;

class Program
{
    static void Main(string[] args)
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();
        DateModifier modifier = new DateModifier(firstDate, secondDate);
        modifier.CalculateDifference(firstDate, secondDate);
    }
}
