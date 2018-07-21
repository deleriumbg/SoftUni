using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[] personInfo = Console.ReadLine().Split();
        string fullName = personInfo[0] + " " + personInfo[1];
        string address = personInfo[2];
        Console.WriteLine(new CustomTuple<string, string>(fullName, address));

        string[] beersInfo = Console.ReadLine().Split();
        string personName = beersInfo[0];
        int beersCount = int.Parse(beersInfo[1]);
        Console.WriteLine(new CustomTuple<string, int>(personName, beersCount));

        string[] input = Console.ReadLine().Split();
        int integerNumber = int.Parse(input[0]);
        double doubleNumber = double.Parse(input[1]);
        Console.WriteLine(new CustomTuple<int, double>(integerNumber, doubleNumber));
    }
}
