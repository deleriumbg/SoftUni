namespace PhotoShare.Client
{
	using System;
	using System.IO;
	using AutoMapper;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	using Data;
	using Core;
	using Core.Contracts;
	using Services;
	using Services.Contracts;

	public class StartUp
	{
		public static void Main()
		{
			var service = ConfigureServices();
			Engine engine = new Engine(service);
			engine.Run();
		}

		private static IServiceProvider ConfigureServices()
		{
			var serviceCollection = new ServiceCollection();

			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			serviceCollection.AddDbContext<PhotoShareContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<PhotoShareProfile>());

			serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
			serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();

			serviceCollection.AddTransient<IAlbumRoleService, AlbumRoleService>();
		    serviceCollection.AddTransient<IAlbumService, AlbumService>();
		    serviceCollection.AddTransient<IAlbumTagService, AlbumTagService>();
            serviceCollection.AddTransient<IPictureService, PictureService>();
		    serviceCollection.AddTransient<ITagService, TagService>();
		    serviceCollection.AddTransient<ITownService, TownService>();
		    serviceCollection.AddTransient<IUserService, UserService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

			return serviceProvider;
		}
	}
}