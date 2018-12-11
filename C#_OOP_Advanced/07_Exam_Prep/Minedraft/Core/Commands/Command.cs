﻿using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected Command(IList<string> arguments)
    {
        this.Arguments = arguments;
    }

    public IList<string> Arguments { get; protected set; }

    public abstract string Execute();
}
