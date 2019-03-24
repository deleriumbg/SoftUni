using System;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Contracts;

namespace MyApp.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider provider;

        public Engine(IServiceProvider services)
        {
            this.provider = services;
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine()?
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var interpreter = this.provider.GetService<ICommandInterpreter>();

                try
                {
                    var result = interpreter.Read(input);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
