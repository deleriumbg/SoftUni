using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        while (true)
        {
            string input = Console.ReadLine();
            string[] inputArgs = input.Split();
            string command = inputArgs[0];
            List<string> args = inputArgs.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(this.draftManager.RegisterHarvester(args));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(this.draftManager.RegisterProvider(args));
                    break;
                case "Day":
                    Console.WriteLine(this.draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(this.draftManager.Mode(args));
                    break;
                case "Check":
                    Console.WriteLine(this.draftManager.Check(args));
                    break;
                case "Shutdown":
                    Console.WriteLine(this.draftManager.ShutDown());
                    return;
            }
        }
    }
}
