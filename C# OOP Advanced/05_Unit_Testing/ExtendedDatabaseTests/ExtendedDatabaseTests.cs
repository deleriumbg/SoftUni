using System;
using System.Linq;
using System.Reflection;
using ExtendedDatabase;
using NUnit.Framework;

namespace ExtendedDatabaseTests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
     
        [Test]
        public void TestWithUserInvalidUsername()
        {
            var arr = new Person[] { new Person(1, "Pesho") };
            var database = new Database<Person>(arr);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, "Pesho")), "Person with that Username or Id already exists!");
        }

        [Test]
        public void TestWithUserInvalidId()
        {
            var arr = new Person[] { new Person(1, "Gosho") };
            var database = new Database<Person>(arr);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "Pesho")),
                "Person with that Username or Id already exists!");
        }

        [Test]
        public void TestToAddAndRemoveSameObjectShouldReturnEmptyAray()
        {
            var database = new Database<Person>();
            database.Add(new Person(1, "Gosho"));
            database.Remove();

            Assert.AreEqual(new Person[0], database.Fetch());
        }

        [Test]
        public void TestWithNegativeId()
        {
            var database = new Database<Person>();

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-2), "The id must be a positive integer!");
        }

        [Test]
        public void TestWithEmptyAndWhitespaceUsername()
        {
            var arr = new Person[] { new Person(1, "Pesho"),new Person(2, "Ivan") };
            var database = new Database<Person>(arr);

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(""));
        }

        [Test]
        public void TestFindByUsernameCaseSensitive()
        {
            var arr = new Person[] { new Person(1, "Pesho"), new Person(2, "Ivan") };
            var database = new Database<Person>(arr);

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("IVan"));
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("PesHo"));
        }

        [Test]
        public void TestCountOfPersons()
        {
            var arr = new Person[] { new Person(1, "Pesho"), new Person(2, "Ivan") };
            var database = new Database<Person>(arr);

            var actualCount = typeof(Database<Person>)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(e => e.Name == "index")
                .GetValue(database);

            Assert.AreEqual(1, actualCount);
        }
    }
}
