using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly ICommandInterpreter commandInterpreter;
    private readonly IReader reader;
    private readonly IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            List<string> inputArgs = reader.ReadLine().Split().ToList();
            string result = commandInterpreter.ProcessCommand(inputArgs);
            writer.WriteLine(result);

            if (inputArgs[0] == "Shutdown")
            {
                break;
            }
        }
    }
}
