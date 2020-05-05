using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void SetControllerShouldReturnFailMessage()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            stage.AddSet(set);

            string actualResult = setController.PerformSets();
            string expectedResult = "1. Set1:\r\n-- Did not perform";

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void SetControllerShouldReturnSuccessMessage()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");

            IPerformer performer = new Performer("Pesho", 20);
            performer.AddInstrument(new Guitar());
            set.AddPerformer(performer);

            ISong song = new Song("Test", new TimeSpan(0, 2, 10));
            set.AddSong(song);

            stage.AddSet(set);

            string actualResult = setController.PerformSets();
            string expectedResult = "1. Set1:\r\n-- 1. Test (02:10)\r\n-- Set Successful";

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void PerformSetsShouldDecreaseInstrumentsWear()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");

            IPerformer performer = new Performer("Pesho", 20);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            set.AddPerformer(performer);

            ISong song = new Song("Test", new TimeSpan(0, 2, 10));
            set.AddSong(song);

            stage.AddSet(set);

            double instrumentWearBeforePerforming = instrument.Wear;
            setController.PerformSets();
            double instrumentWearAfterPerforming = instrument.Wear;

            Assert.That(instrumentWearBeforePerforming, Is.Not.EqualTo(instrumentWearAfterPerforming));
        }
    }
}