using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] commandArgs = command.Split(' ');
            string commandType = commandArgs[0];

            switch (commandType)
            {
                case "Create":
                    Create(commandArgs, accounts);
                    break;
                case "Deposit":
                    Deposit(commandArgs, accounts);
                    break;
                case "Withdraw":
                    Withdraw(commandArgs, accounts);
                    break;
                case "Print":
                    Print(commandArgs, accounts);
                    break;
                default:
                    break;
            }
            command = Console.ReadLine();
        }

    }

    private static void Print(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(commandArgs[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine(accounts[id]);
        }
    }

    private static void Withdraw(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(commandArgs[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            if (accounts[id].Balance >= decimal.Parse(commandArgs[2]))
            {
                accounts[id].Balance -= decimal.Parse(commandArgs[2]);
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
    }

    private static void Deposit(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(commandArgs[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            accounts[id].Balance += decimal.Parse(commandArgs[2]);
        }
    }

    private static void Create(string[] commandArgs, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(commandArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            BankAccount acc = new BankAccount();
            acc.Id = id;
            accounts.Add(id, acc);
        }
    }
}
