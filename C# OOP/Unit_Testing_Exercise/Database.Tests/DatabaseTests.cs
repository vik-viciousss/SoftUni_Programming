using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database.Database();
        }

        [Test]
        public void When_AddIsCalledWithMoreThanCapacity_ShouldThrowInvalidOperation()
        {
            Assert.That(() =>
            {
                for (int i = 0; i < 17; i++)
                {
                    database.Add(i);
                }
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));

        }

        [Test]
        public void When_AddIsCalled_ShouldAddElementToLatestPosition()
        {
            int n = 7;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }

            Assert.That(this.database.Count, Is.EqualTo(n));
        }

        [Test]
        public void When_AddIsInvoked_ShouldAddElementToDatabase()
        {
            int element = 12;

            this.database.Add(element);

            int[] elements = this.database.Fetch();

            Assert.That(elements, Does.Contain(element));
        }

        [Test]
        public void When_RemoveIsCalled_ShouldDecreaseCount()
        {
            int n = 5;
            for (int i = 0; i <= n; i++)
            {
                this.database.Add(i);
            }

            this.database.Remove();

            Assert.That(this.database.Count == n);

        }

        [Test]
        public void When_RemoveIsCalledWithEmptyDatabase_ShouldThrow()
        {
            Assert.That(() =>
            {
                this.database.Remove();
            }, Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void When_RemoveIsCalled_ShouldRemoveTheLastElement()
        {

            int n = 5;
            for (int i = 0; i <= n; i++)
            {
                this.database.Add(i);
            }

            this.database.Remove();
            int[] elements = this.database.Fetch();

            Assert.IsFalse(elements.Contains(n));
        }

        [Test] 
        public void When_FetchIsCalled_ShouldReturnCopyOfArray()
        {
            int n = 5;
            for (int i = 0; i <= n; i++)
            {
                this.database.Add(i);
            }

            int[] firstCopy = this.database.Fetch();

            this.database.Add(n + 1);

            int[] secondCopy = this.database.Fetch();

            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }

        [Test]
        public void When_DatabaseIsEmpty_ShouldReturnZeroCount()
        {
            Assert.That(this.database.Count, Is.EqualTo(0));
        }

        [Test] 
        public void When_DatabaseCapacityIsExceeded_CtorShouldThrow()
        {
            int[] elements = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17};

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database.Database(elements);
            });
        }

        [Test] 
        public void When_DatabaseIsCreated_ShouldAddElementsToDatabase()
        {
            int[] elements = new int[] { 1, 2, 3 };
            this.database = new Database.Database(elements);

            Assert.That(this.database.Count, Is.EqualTo(elements.Length));
            Assert.That(this.database.Fetch(), Is.EquivalentTo(elements));

            //Assert.That(this.database.data.Capasity == 16);
        }
    }
}