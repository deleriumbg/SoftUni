using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using StorageMaster;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class ProductTests
    {
        private Type product;

        [SetUp]
        public void SetUp()
        {
            this.product = this.GetType("Product");
        }

        [Test]
        public void ValidateAllProductClasses()
        {
            var expected = new string[] {
                "Gpu",
                "Ram",
                "HardDrive",
                "SolidStateDrive",
                "Product"
            };

            foreach (var product in expected)
            {
                var currentType = GetType(product);

                Assert.That(currentType, Is.Not.Null,$"Class with name {product} does not exist");
            }
        }

        [Test]
        public void ValidateProductBaseClasses()
        {
            var expected = new string[] {
                "Gpu",
                "Ram",
                "HardDrive",
                "SolidStateDrive",
            };

            foreach (var name in expected)
            {
                var expectedType = GetType(name);

                Assert.That(expectedType.BaseType, Is.EqualTo(this.product), $"{name} class not inherits {this.product.Name}");
            }
        }

        [Test]
        public void ValidateProductConstructorParams()
        {
            var constructor = this.product.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault();

            Assert.That(constructor, Is.Not.Null);

            var constructorParams = constructor.GetParameters();

            for (int i = 0; i < constructorParams.Length; i++)
            {
                Assert.That(constructorParams[i].ParameterType, Is.EqualTo(typeof(double)));
            }
        }

        [Test]
        public void ValidateProductFields()
        {
            var actualField = this.product.GetField("price" ,BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(actualField, Is.Not.Null, $"Field with name price does not exists");
            Assert.That(actualField.IsPrivate, $"Field price must be privete");
            Assert.That(actualField.FieldType, Is.EqualTo(typeof(double)));
        }

        [Test]
        public void ValidateProductProperties()
        {
            var actualProperties = this.product.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var expectedProperties = new Dictionary<string, Type>
            {
                { "Price", typeof(double) },
                { "Weight", typeof(double) }
            };

            foreach (var propertyPair in expectedProperties)
            {
                var expectedPropery = this.product.GetProperty(propertyPair.Key);

                Assert.That(expectedPropery, Is.Not.Null, 
                    $"Property with name {propertyPair.Key} does not exists!");

                var isPublicGetter = expectedPropery.CanRead;
                Assert.That(isPublicGetter, $"Property with name {propertyPair.Key} do not have public getter!");
            }
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
