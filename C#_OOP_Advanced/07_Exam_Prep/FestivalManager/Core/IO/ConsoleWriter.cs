using System;
using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string contents)
        {
            Console.WriteLine(contents);
        }

        public void Write(string contents)
        {
            Console.Write(contents);
        }
    }
}
