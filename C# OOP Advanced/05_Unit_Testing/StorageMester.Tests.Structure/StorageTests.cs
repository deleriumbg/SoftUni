using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public  class StorageTests
    {
        private Type storage;

        [SetUp]
        public void SetUp()
        {
            this.storage = GetType("Storage");
        }

        [Test]
        public void ValidateStorageClasses()
        {
            var expected = new string[]
            {
                "Storage", 
                "Warehouse", 
                "DistributionCenter", 
                "AutomatedWarehouse"
            };

            foreach (var className in expected)
            {
                var classType = GetType(className);
                Assert.That(classType, Is.Not.Null,$"Class with {className} does not exist!");
            }
        }

        [Test]
        public void ValidateChildClasses()
        {
            var expected = new string[]
            {
                "Warehouse", 
                "DistributionCenter", 
                "AutomatedWarehouse"
            };

            foreach (var expectedName in expected)
            {
                Assert.That(GetType(expectedName).BaseType, Is.EqualTo(this.storage),$"Class {expectedName} must inherit {this.storage.Name}!");
            }
        }

        [Test]
        public void ValidateStorageFields()
        {
            var expectedFields = new Dictionary<string, Type>
            {
                { "garage", typeof(Vehicle[]) },
                { "products", typeof(List<Product>) }
            };

            foreach (var expectedFieldPair in expectedFields)
            {
                var expectedField = this.storage.GetField(expectedFieldPair.Key,BindingFlags.NonPublic | BindingFlags.Instance);

                Assert.That(expectedField, Is.Not.Null,
                    $"Field with name {expectedFieldPair.Key} does not exists!");

                var isPrivateAndReadOnly = expectedField.Attributes.HasFlag(FieldAttributes.InitOnly | FieldAttributes.Private);
                Assert.That(isPrivateAndReadOnly,
                    $"Field with name {expectedFieldPair.Key} must be private and readonly");

                var fieldType = expectedField.FieldType;
                Assert.That(fieldType, Is.EqualTo(expectedFieldPair.Value),
                    $"Field with name {expectedFieldPair.Key} must have type of {expectedFieldPair.Value.Name}");
            }
        }

        [Test]
        public void ValidatePublicMethods()
        {
            var expectedMethods = new Method[]
            {
                new Method( typeof(Vehicle), "GetVehicle", typeof(int)),
                new Method( typeof(int), "SendVehicleTo", typeof(int), typeof(Storage)),
                new Method( typeof(int), "UnloadVehicle", typeof(int)),           
            };

            foreach (var methodClass in expectedMethods)
            {
                var currentMethod = this.storage.GetMethod(methodClass.Name);
                Assert.That(currentMethod, Is.Not.Null, $"Method with name {methodClass.Name} does not exist");

                var returnType = currentMethod.ReturnType;
                Assert.That(returnType, Is.EqualTo(methodClass.ReturnType),
                    $"Method with name {methodClass.Name} return type must be {methodClass.ReturnType.Name}");

                var actualParams = currentMethod.GetParameters();
                var expectedParams = methodClass.InputParameters;

                for (int i = 0; i < expectedParams.Length ; i++)
                {
                    var actualParam = actualParams[i].ParameterType;
                    var expected = expectedParams[i];

                    Assert.That(actualParam, Is.EqualTo(expected),
                        $"Parameter with name {expected.Name} is not valid");
                }
            }
        }

        [Test]
        public void ValidatePrivateMethods()
        {
              var expectedMethods = new Method[]
            {
                new Method(typeof(int), "AddVehicle", typeof(Vehicle)),
                new Method(typeof(void), "InitializeGarage", typeof(IEnumerable<Vehicle>))
            };

            foreach (var methodClass in expectedMethods)
            {
                var currentMethod = this.storage.GetMethod(methodClass.Name,BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.That(currentMethod, Is.Not.Null, $"Method with name {methodClass.Name} does not exist");

                var returnType = currentMethod.ReturnType;
                Assert.That(returnType, Is.EqualTo(methodClass.ReturnType),
                    $"Method with name {methodClass.Name} return type must be {methodClass.ReturnType.Name}");

                var actualParams = currentMethod.GetParameters();
                var expectedParams = methodClass.InputParameters;

                for (int i = 0; i < expectedParams.Length ; i++)
                {
                    var actualParam = actualParams[i].ParameterType;
                    var expected = expectedParams[i];

                    Assert.That(actualParam, Is.EqualTo(expected),
                        $"Parameter with name {expected.Name} is not valid");
                }
            }
        }

        private class Method
        {
            public Method(Type returnType, string name, params Type[] inputParameters)
            {
                this.ReturnType = returnType;
                this.Name = name;
                this.InputParameters = inputParameters;
            }

            public Type ReturnType { get; set; }

            public string Name { get; set; }

            public Type[] InputParameters { get; set; }
        }
        public Type GetType(string type)
        {
            var targetType = typeof(StartUp)
                    .Assembly
                    .GetTypes()
                    .FirstOrDefault(x => x.Name == type);

            return targetType;
        }
    }
}
