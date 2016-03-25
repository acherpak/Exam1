using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamProject;

namespace ListTest
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void TestLength()
        {
            ILinkedList<int> list = PrepareListof10Int();
            int expectedLength = 10;

            Assert.AreEqual(expectedLength, list.Lenght(), "Incorrect length!");
        }

        [TestMethod]
        public void TestFind()
        {
            ILinkedList<int> list = PrepareListof10Int();
            bool result = true;

            Assert.AreEqual(result, list.Find(7), "It is not there");
        }

        [TestMethod]
        public void TestPrint()
        {
            IPrintable list = PrepareListof10Int();
            list.Print();
        }

        [TestMethod]
        public void TestRemove()
        {
            ILinkedList<int> list = PrepareListof10Int();
            list.Remove(10);
            bool result = false;
            Assert.AreEqual(result, list.Find(10), "It is not there");
        }

        [TestMethod]
        public void TestListValidity()
        {
            ILinkedList<string> list = PrepareListof4Strings();
            bool works = list.First().DataValue == "one";
            works = works & list.First().Next.DataValue == "two";
            works = works & list.First().Next.Next.DataValue == "three";

            Assert.IsTrue(works, "The list is wrong!");
        }

        private LinkedListGeneric<int> PrepareListof10Int()
        {
            LinkedListGeneric<int> list = new LinkedListGeneric<int>();
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.AddFirst(8);
            list.AddLast(9);
            list.AddFirst(10);

            return list;

        }

        private LinkedListGeneric<string> PrepareListof4Strings()
        {
            LinkedListGeneric<string> list = new LinkedListGeneric<string>();
            list.AddFirst("one");
            list.AddLast("two");
            list.AddLast("three");
            list.AddLast("four");

            return list;

        }
    }
}
