using System;

class Program
{
    static void Main(string[] args)
    {
        string[] personInfo = Console.ReadLine().Split();
        string fullName = personInfo[0] + " " + personInfo[1];
        string address = personInfo[2];
        string town = personInfo[3];
        Console.WriteLine(new Threeuple<string, string, string>(fullName, address, town));

        string[] beersInfo = Console.ReadLine().Split();
        string personName = beersInfo[0];
        int beersCount = int.Parse(beersInfo[1]);
        bool isDrunk = beersInfo[2] == "drunk";
        Console.WriteLine(new Threeuple<string, int, bool>(personName, beersCount, isDrunk));

        string[] input = Console.ReadLine().Split();
        string accountName = input[0];
        double doubleNumber = double.Parse(input[1]);
        string bankName = input[2];
        Console.WriteLine(new Threeuple<string, double, string>(accountName, doubleNumber, bankName));
    }
}
