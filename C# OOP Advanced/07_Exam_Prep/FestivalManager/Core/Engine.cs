using System;
using System.Linq;

namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFestivalController festivalCоntroller;
        private readonly ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string result;
                try
                {
                    result = this.ProcessCommand(input);
                }
                catch (TargetInvocationException tie)
                {
                    result = "ERROR: " + tie.InnerException.Message;
                }
                catch (Exception ex)
                {
                    result = "ERROR: " + ex.Message;
                }
                this.writer.WriteLine(result);
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var inputArgs = input.Split();

            var command = inputArgs[0];
            var args = inputArgs.Skip(1).ToArray();

            string result;

            if (command == "LetsRock")
            {
                result = this.setCоntroller.PerformSets();
            }
            else
            {
                var festivalControllerMethod = this.festivalCоntroller.GetType()
                    .GetMethods()
                    .FirstOrDefault(x => x.Name == command);

                result = (string)festivalControllerMethod.Invoke(this.festivalCоntroller, new object[] { args });
            }

            return result;
        }
    }
}