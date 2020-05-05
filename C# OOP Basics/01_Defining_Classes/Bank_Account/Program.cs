using System;

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount
        {
            Id = 1,
            Balance = 15
        };

        Console.WriteLine($"Account {account.Id}, balance {account.Balance}");
    }
}
