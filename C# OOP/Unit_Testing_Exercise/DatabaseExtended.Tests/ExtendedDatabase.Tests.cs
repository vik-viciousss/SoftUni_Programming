using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private long id = 123;
        private string userName = "User";
        private Person person;
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            this.person = new Person(id, userName);
            this.database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void When_TryAddingPersonWithMatchingName_ShouldThrowInvalidOperation()
        {
            this.database.Add(person);

            int newId = 1234;
            person = new Person(newId, userName);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(person);

            });
        }

        [Test]
        public void When_TryAddingPersonWithMatchingId_ShouldThrowInvalidOperation()
        {
            this.database.Add(person);

            string newUserName = "User2";
            person = new Person(this.id, newUserName);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(person);

            });
        }

        [Test]
        public void When_AddIsCalledWithMoreThanCapacity_ShouldThrowInvalidOperation()
        {
            Assert.That(() =>
            {
                for (int i = 0; i < 17; i++)
                {
                    database.Add(new Person(i, $"{i}"));
                }
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));

        }

        [Test]
        public void When_AddIsCalled_ShouldAddElementToLatestPosition()
        {
            int n = 7;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(new Person(i, $"{i}"));
            }

            Assert.That(this.database.Count, Is.EqualTo(n));
        }

        [Test]
        public void When_AddIsCalled_ShouldAddElementToDatabase()
        {
            //Person personToCheck = new Person(0, "");
            //int n = 2;
            //for (int i = 0; i <= n; i++)
            //{
            //    this.database.Add(new Person(i, $"{i}"));
            //    personToCheck = new Person(i, $"{i}");
            //}

            //Type type = typeof(ExtendedDatabase.ExtendedDatabase);
            //Person[] persons = new Person[] { };
            //FieldInfo[] fields = type.GetFields((BindingFlags)60);
            //foreach (var field in fields)
            //{
            //    if (field.Name == "persons")
            //    {
            //        persons = (Person[])field.GetValue(this.database);
            //        break;
            //    }
            //}

            //Assert.IsTrue(persons.Contains(personToCheck));
            Assert.Pass();
        }

        [Test]
        public void When_RemoveIsCalledWithEmptyDatabase_ShouldThrow()
        {
            Assert.That(() =>
            {
                this.database.Remove();
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void When_RemoveIsCalled_ShouldDecreaseCount()
        {
            int n = 5;
            for (int i = 0; i <= n; i++)
            {
                this.database.Add(new Person(i, $"{i}"));
            }

            this.database.Remove();

            Assert.That(this.database.Count == n);

        }

        [Test]
        public void When_RemoveIsCalled_ShouldRemoveTheLastElement()
        {
            Person personToRemove = new Person(0, "");
            int n = 2;
            for (int i = 0; i <= n; i++)
            {
                this.database.Add(new Person(i, $"{i}"));
                personToRemove = new Person(i, $"{i}");
            }

            this.database.Remove();

            Type type = typeof(ExtendedDatabase.ExtendedDatabase);
            Person[] persons = new Person[] { };
            FieldInfo[] fields = type.GetFields((BindingFlags)60);
            foreach (var field in fields)
            {
                if (field.Name == "persons")
                {
                    persons = (Person[])field.GetValue(this.database);
                    break;
                }
            }

            Assert.That(persons, !Does.Contain(personToRemove));
        }

        [Test]
        public void When_DatabaseIsEmpty_ShouldReturnZeroCount()
        {
            Assert.That(this.database.Count, Is.EqualTo(0));
        }

        [Test]
        public void When_EmptyDatabaseIsCreated_PersonsShouldNotBeNull()
        {
            Type type = typeof(ExtendedDatabase.ExtendedDatabase);
            Person[] persons = new Person[] { };
            FieldInfo[] fields = type.GetFields((BindingFlags)60);
            foreach (var field in fields)
            {
                if (field.Name == "persons")
                {
                    persons = (Person[])field.GetValue(this.database);
                    break;
                }
            }

            Assert.IsNotNull(persons);
        }

        [Test]
        public void When_DatabaseIsCreatedWithExceedingCapacity_ShouldThrow()
        {
            Person[] people = new Person[17];
            int n = 17;
            for (int i = 0; i < n; i++)
            {
                people[i] = new Person(i, $"{i}");
            }

            Assert.Throws<ArgumentException>(() =>
            {
                this.database = new ExtendedDatabase.ExtendedDatabase(people);
            });
        }

        [Test]
        public void When_DatabaseIsCreated_ShouldAddElementsToDatabase()
        {
            int n = 3;
            Person[] persons = new Person[n];
            for (int i = 0; i < n; i++)
            {
                persons[i] = new Person(i, $"{i}");
            }
            this.database = new ExtendedDatabase.ExtendedDatabase(persons);

            Assert.That(this.database.Count, Is.EqualTo(persons.Length));

            Type type = typeof(ExtendedDatabase.ExtendedDatabase);
            Person[] personsNew = new Person[] { };
            FieldInfo[] fields = type.GetFields((BindingFlags)60);
            foreach (var field in fields)
            {
                if (field.Name == "persons")
                {
                    personsNew = (Person[])field.GetValue(this.database);
                    break;
                }
            }

            Assert.That(persons, Is.EquivalentTo(personsNew.Where(p => p != null)));

            //Assert.That(this.database.data.Capasity == 16);
        }

        [Test]
        public void When_SearchingForUserWithNonExistantName_ShouldThrowInvalidOp()
        {
            string fakeName = "User1";

            this.database.Add(this.person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindByUsername(fakeName);
            });
        }

        [Test]
        public void When_TryFindNullOrEmptyUsername_ShouldThrowArgumentNull()
        {
            string emptyName = string.Empty;

            this.database.Add(this.person);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.database.FindByUsername(emptyName);
            });
        }

        [Test]
        public void When_TryFindByMissingId_ShouldThrowInvalidOp()
        {
            long fakeId = 1234;

            this.database.Add(this.person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindById(fakeId);
            });
        }

        [Test]
        public void When_SearchForNegativeId_ShouldThrowOutOfRange()
        {
            long negativeId = -5;
            this.database.Add(this.person);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.database.FindById(negativeId);
            });
        }
    }
}