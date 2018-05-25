using System;

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        account.Id = 1;
        account.Deposit(15);
        account.Withdraw(10);

        Console.WriteLine(account);
    }
}
