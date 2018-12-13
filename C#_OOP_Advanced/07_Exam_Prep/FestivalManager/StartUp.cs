using FestivalManager.Entities.Factories;
using FestivalManager.Entities.Factories.Contracts;

namespace FestivalManager
{
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
			IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IStage stage = new Stage();
            ISetFactory setFactory = new SetFactory();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();

            IFestivalController festivalController = new FestivalController(stage, setFactory, instrumentFactory);
            ISetController setController = new SetController(stage);

			IEngine engine = new Engine(reader, writer, festivalController, setController);
            engine.Run();
		}
	}
}