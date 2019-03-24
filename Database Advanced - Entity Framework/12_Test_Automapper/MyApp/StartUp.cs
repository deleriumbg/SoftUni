using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core;
using MyApp.Core.Contracts;
using MyApp.Data;

namespace MyApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider services = ConfigureServices();

            IEngine engine = new Engine(services);
            engine.Run();
        }

        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<EmployeesMappingContext>();
            services.AddTransient<ICommandInterpreter, CommandInterpreter>();
            services.AddTransient<Mapper>();

            return services.BuildServiceProvider();
        }
    }
}
