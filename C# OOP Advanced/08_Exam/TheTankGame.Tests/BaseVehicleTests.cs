using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Parts;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Vehicles;
using TheTankGame.Entities.Vehicles.Contracts;

namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void EmptyModelThrowsException()
        {
            Assert.That(() => new Revenger("", 10, 20, 30, 40, 50, new VehicleAssembler()), Throws.Exception.TypeOf<ArgumentException>().With.Property("Message").EqualTo("Model cannot be null or white space!"));
              
        }

        [Test]
        public void NegativeArgumentThrowsException()
        {
            Assert.That(() => new Revenger("Pesho", -1, 20, 30, 40, 50, new VehicleAssembler()), Throws.Exception.TypeOf<ArgumentException>().With.Property("Message").EqualTo("Weight cannot be less or equal to zero!"));
              
        }

        [Test]
        public void TotalWeightTest()
        {
            
            IAssembler assembler = new VehicleAssembler();
            IVehicle vehicle = new Revenger("Pesho2", 3, 4, 5, 6, 7, assembler);
            IPart arsenalPart = new ArsenalPart("kor", 5, 3, 5);
            IPart endurancePart = new EndurancePart("pesho", 6, 3, 5);
            IPart shellPart = new ShellPart("kor5", 5, 3, 6);
            assembler.AddArsenalPart(arsenalPart);
            assembler.AddEndurancePart(endurancePart);
            assembler.AddShellPart(shellPart);

            Assert.That(assembler.TotalWeight, Is.EqualTo(16.0d));
            Assert.That(assembler.TotalPrice, Is.EqualTo(9m));
            Assert.That(assembler.ArsenalParts.Count, Is.EqualTo(1));
            Assert.That(assembler.EnduranceParts.Count, Is.EqualTo(1));
            Assert.That(assembler.ShellParts.Count, Is.EqualTo(1));

            Assert.That(vehicle.ToString(), Is.EqualTo("Revenger - Pesho2\r\nTotal Weight: 19.000\r\nTotal Price: 13.000\r\nAttack: 10\r\nDefense: 12\r\nHitPoints: 12\r\nParts: None"));
        }
    }
}