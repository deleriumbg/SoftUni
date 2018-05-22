using System;

class InstructionSet_broken
{
    static void Main()
    {
        string command = Console.ReadLine();
        long result = 0;
        long operandOne = 0;
        long operandTwo = 0;

        while (command != "END")
        {
            string[] commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (commandArgs[0])
            {
                case "INC":
                    {
                        operandOne = long.Parse(commandArgs[1]);
                        result = operandOne + 1;
                        Console.WriteLine(result);
                        break;
                    }
                case "DEC":
                    {
                        operandOne = long.Parse(commandArgs[1]);
                        result = operandOne - 1;
                        Console.WriteLine(result);
                        break;
                    }
                case "ADD":
                    {
                        operandOne = long.Parse(commandArgs[1]);
                        operandTwo = long.Parse(commandArgs[2]);
                        result = operandOne + operandTwo;
                        Console.WriteLine(result);
                        break;
                    }
                case "MLA":
                    {
                        operandOne = long.Parse(commandArgs[1]);
                        operandTwo = long.Parse(commandArgs[2]);
                        result = operandOne * operandTwo;
                        Console.WriteLine(result);
                        break;
                    }
            }
            command = Console.ReadLine();
        } 
    }
}