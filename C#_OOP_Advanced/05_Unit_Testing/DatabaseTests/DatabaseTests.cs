using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace DatabaseTests
{
    [TestFixture]
    public class DatabaseTests
    {
        private const int InitialCapacity = 16;
        private Type dbType;
        private Database.Database database;

        [SetUp]
        public void TestInit()
        {
            this.dbType = typeof(Database.Database);
            this.database = new Database.Database();
        }

        [Test]
        public void TestEmptyConstructorData()
        {
            var data = dbType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(e => e.Name == "data")
                .GetValue(database);
       
            var actualLength = ((int[]) data).Length;
            var expectedLength = InitialCapacity;

            Assert.That(actualLength, Is.EqualTo(expectedLength));
        }

        [Test]
        public void TestEmptyConstructorIndex()
        {
            var actualIndex = (int)dbType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(e => e.Name == "index")
                .GetValue(database);

            var expectedIndex = -1;

            Assert.That(() => actualIndex, Is.EqualTo(expectedIndex));
        }

        [Test]
        public void TestEmptyConstructorShouldReturnNoElements()
        {
            var fetchResult = database.Fetch();
            var expected = new int[0];

            Assert.AreEqual(expected, fetchResult);
        }

        [Test]
        public void ShouldThrowExceptionIfDataIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove(),
                "Database is empty. You cannot remove elements");
        }

        [Test]
        public void ShouldThrowAnErrorIfAddMoreThanCapacity()
        {
            for (int i = 0; i < InitialCapacity; i++)
            {
                database.Add(1);
            }

            var actualResult = string.Join("", database.Fetch());
            var expectedResult = new string('1', 16);

            var actualIndex = dbType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(e => e.Name == "index")
                .GetValue(database);

            var expectedIndex = InitialCapacity - 1;

            Assert.AreEqual(actualIndex, expectedIndex);
            Assert.AreEqual(expectedResult, actualResult);
            Assert.Throws<InvalidOperationException>(() => database.Add(1),
                "Database is full. You cannot add any elements");
        }

        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6 })]
        public void TestDataCapacity(int[] items)
        {
            var database = new Database.Database(items);

            var actualData = (int[])dbType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
               .FirstOrDefault(е => е.Name == "data")
                ?.GetValue(database);

            var actualLength = actualData.Length;
            var expectedLength = InitialCapacity;

            Assert.That(() => actualLength == expectedLength);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6 })]
        public void TestIndex(int[] items)
        {
            var database = new Database.Database(items);

            var index = (int)dbType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == "index").GetValue(database);

            Assert.That(() => items.Length - 1, Is.EqualTo(index));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6 })]
        public void TestFetchMethod(int[] items)
        {
            var database = new Database.Database(items);

            var actualArr = string.Join("", database.Fetch());
            var expectedArr = string.Join("", items);

            Assert.AreEqual(expectedArr, actualArr);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6,5 })]
        public void ShouldThrowErrorIfInputArrCapacityisBigerThanNeeded(int[] items)
        {
            Assert.Throws<InvalidOperationException>(() => new Database.Database(items), $"Items must be lest than {InitialCapacity}");
        }

        [Test]
        [TestCase(new int[0] )]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5})]
        public void ShouldReturnEmptyArrayIfAllIndexAreRemoved(int[] items)
        {
            var database = new Database.Database(items);

            for (int i = 0; i < items.Length; i++)
            {
                database.Remove();
            }

            var actual = database.Fetch();
            var expected = new int[0];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[0])]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void SouldThrowErrorAfterRemoveAllElements(int[] items)
        {
            var database = new Database.Database(items);

            for (int i = 0; i < items.Length; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove(), "Database is empty. You cannot remove elements");
        }
    }
}
