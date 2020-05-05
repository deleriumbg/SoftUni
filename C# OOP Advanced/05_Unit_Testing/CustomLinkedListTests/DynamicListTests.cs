using System;
using CustomLinkedList;
using NUnit.Framework;

namespace CustomLinkedListTests
{
    [TestFixture]
    public class DynamicListTests
    {
        private DynamicList<int> list;
        private Type type;

        [SetUp]
        public void TestInit()
        {
            var type = typeof(DynamicList<int>);
            this.list = Activator.CreateInstance<DynamicList<int>>();
        }


        [Test]
        public void CheckConstructorSetValues()
        {
            var actual = this.list.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IndexOperatorShouldReturnValue()
        {
            list.Add(1);
            list.Add(2);

            int element = list[1];
            Assert.That(element, Is.EqualTo(2));
        }

        [Test]
        public void IndexOperatorShouldSetValue()
        {
            list.Add(1);
            list.Add(2);
            list[1] = 13;
            int element = list[1];
            Assert.That(element, Is.EqualTo(13));
            Assert.That(list.Count, Is.EqualTo(2));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-4)]
        [TestCase(2)]
        public void IsIndexValid(int index)
        {
            list.Add(2);
            list.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => list[index].ToString(), $"Invalid index: {index}");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-4)]
        [TestCase(2)]
        public void RemoveOutsideShouldThrowError(int index)
        {
            list.Add(2);
            list.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(index), $"Invalid index: {index}");
        }
        
        [Test]
        [TestCase(new int[] {1,2,3,4 }, 0)]
        [TestCase(new int[] {1,2,3,4 }, 3)]
        [TestCase(new int[] {1,2,3,4 }, 2)]
        public void CheckRemoveAtFunction(int[] arr,int index)
        {
            foreach (var item in arr)
            {
                list.Add(item);
            }

            var actual = list[index];
            var expected = arr[index];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(0)]
        [TestCase(16)]
        public void CheckRemoveOutOfRange(int item)
        {
            for (int i = 1; i < 16; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(-1, list.Remove(item));
        }

        [Test]
        [TestCase(0)]
        [TestCase(8)]
        [TestCase(16)]
        public void CheckRemoveWorkCorrectly(int item)
        {
            for (int i = 0; i <= 16; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(item, list.Remove(item));
        }

        [Test]
        [TestCase(0)]
        [TestCase(8)]
        [TestCase(16)]
        public void CheckIndexofCorrectValues(int item)
        {
            for (int i = 0; i <= 16; i++)
            {
                list.Add(i);
            }

            Assert.AreNotEqual(-1, list.IndexOf(item));
        }

        [Test]
        [TestCase(0)]
        [TestCase(16)]
        public void CheckIndexofValuesAreNotCorrect(int item)
        {
            for (int i = 1; i < 16; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(-1, list.IndexOf(item));
        }
    }
}
