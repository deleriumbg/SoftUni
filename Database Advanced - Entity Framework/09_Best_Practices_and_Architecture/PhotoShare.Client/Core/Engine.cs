﻿namespace PhotoShare.Client.Core
{
	using System;
	using System.Data.SqlClient;
	using Microsoft.Extensions.DependencyInjection;
	using Contracts;
	using Services.Contracts;

	public class Engine : IEngine
	{
		private readonly IServiceProvider serviceProvider;

		public Engine(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public void Run()
		{
			var initializeService = this.serviceProvider.GetService<IDatabaseInitializerService>();
			initializeService.InitializeDatabase();

			var commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();

			while (true)
			{
				try
				{
                    Console.WriteLine("Enter command:");
					string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
					string result = commandInterpreter.Read(input);
					Console.WriteLine(result);
				}
				catch (Exception exception) when (exception is SqlException || exception is ArgumentException ||
				                                  exception is InvalidOperationException)
				{
					Console.WriteLine(exception.Message);
				}
			}
		}
	}
}