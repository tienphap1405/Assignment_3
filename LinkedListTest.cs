//Create a LinkedListTest class that using for testing the functions of the SLL class
using Assignment_3.ProblemDomain;
using Assignment_3.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    [TestFixture]
    public class LinkedListTest
    {
        private ILinkedListADT user;
        [SetUp]
        public void Setup()
        {
            user = new SLL();
            user.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            user.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            user.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            user.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            user.Clear();
        }

        //Test if the list is empty after being clear
        [Test]
        public void TestIsEmpty()
        {
            user.Clear();
            Assert.IsTrue(user.IsEmpty());
        }

        //Test if the AddFirst function works as expected
        [Test]
        public void TestAddFirst()
        {
            user.AddFirst(new User(5, "Johnson", "js@gmail.com", "asdwe"));
            string expectedName = "Johnson";
            User? actual = user.GetValue(0);
            Assert.AreEqual(expectedName, actual.Name);

        }

        //Test if the AddLast function works as expected
        [Test]
        public void TestAddLast()
        {
            string expectedName = "Ronald McDonald";
            User? actual = user.GetValue(3);
            Assert.AreEqual(expectedName, actual.Name);
        }

        [Test]
        public void TestAddAtIndex()
        {
            user.Add(new User(5, "Johnson", "js@gmail.com", "asdwe"), 3);
            string expected = "Johnson";
            User? actual = user.GetValue(3);
            Assert.AreEqual(expected, actual.Name);
        }

        [Test]
        public void TestReplaced()
        {
            user.Replace(new User(5, "Johnson", "js@gmail.com", "asdwe"), 2);
            string expected = "Johnson";
            User? actual = user.GetValue(2);
            Assert.AreEqual(expected, actual.Name);
        }

        [Test]
        public void TestRemoveAtFirst()
        { 
            user.RemoveFirst();
            string expected = "Joe Schmoe";
            User? actual = user.GetValue(0);
            Assert.AreEqual(expected, actual.Name);
        }

        [Test] 
        public void TestRemoveAtLast() 
        {
            user.RemoveLast();
            string expected = "Colonel Sanders";
            User? actual = user.GetValue(2);
            Assert.AreEqual(expected, actual.Name);
        }

        [Test]
        public void TestRemoveAtIndex()
        {
            user.Remove(2);
            string expected = "Ronald McDonald";
            User? actual = user.GetValue(2);
            Assert.AreEqual(expected, actual.Name);
        }

        [Test]
        public void TestIndexOf()
        {
            User expectedUser = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            int actual = user.IndexOf(expectedUser);
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestIsContains()
        {
            User expectedUser = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            Assert.IsTrue(user.Contains(expectedUser));
        }

        //The functionality to test if the method of copying to Array works as expected
        [Test]
        public void TestCopyToArray()
        {
            User[] ExpectedOutputArray = user.CopyToArray();

            Assert.AreEqual(4, ExpectedOutputArray.Length);
            Assert.AreEqual("Joe Blow", ExpectedOutputArray[0].Name);

            Assert.AreEqual(1, ExpectedOutputArray[0].Id);
            Assert.AreEqual("Ronald McDonald", ExpectedOutputArray[3].Name);
        }
    }
}
