namespace Problem01.CircularQueue.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using NUnit.Framework;
    using System.Runtime.CompilerServices;
    using Problem01.CircularQueue;

    [TestFixture]
    public class QueueTests
    {
        private IAbstractQueue<int> queue;
        private Queue<int> builtInQueue;

        [SetUp]
        public void InitializeQueue()
        {
            this.queue = new CircularQueue<int>();
            this.builtInQueue = new Queue<int>();
        }

        private static IEnumerable<int[]> RandomCollections()
        {
            var collections = new List<int[]>
            {
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                new int[] { 3, 8, 1, 6, 5, 7, 2, 9, 4 },
                new int[] { 3, 8, 1 },
                new int[] { 3 },
                new int[] { 3, 8, 1, 3, 8, 1, 6, 5, 7, 2, 9, 4, 3, 8, 1, 6, 5, 7, 2, 9, 4 }
            };

            return collections;
        }

        [Test]
        public void Enqueue_SingleElement_ShouldIncreaseCount()
        {
            this.queue.Enqueue(1);
            Assert.AreEqual(1, this.queue.Count);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Enqueue_MultipleElements_ShouldOrderElementsCorrectly(int[] expected)
        {

            foreach (var num in expected)
            {
                this.queue.Enqueue(num);
                this.builtInQueue.Enqueue(num);
            }

            CollectionAssert.AreEqual(this.builtInQueue, this.queue);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Enqueue_MultipleElements_ShouldIncreaseCount(int[] expected)
        {
            foreach (var num in expected)
            {
                this.queue.Enqueue(num);
                this.builtInQueue.Enqueue(num);
            }

            Assert.AreEqual(this.builtInQueue.Count, this.queue.Count);
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Dequeue_WithMultipleElements_ShouldRemoveTheFirstElement(int[] expected)
        {
            foreach (var num in expected)
            {
                this.queue.Enqueue(num);
                this.builtInQueue.Enqueue(num);
            }

            do
            {
                Assert.AreEqual(this.builtInQueue.Dequeue(), this.queue.Dequeue());
            }
            while (this.queue.Count > 0);
        }

        [Test]
        public void Dequeue_WithSingeElement_ShouldDecreaseCount()
        {
            Assert.AreEqual(0, this.queue.Count);
            this.queue.Enqueue(10);

            Assert.AreEqual(1, this.queue.Count);

            this.queue.Dequeue();
            Assert.AreEqual(0, this.queue.Count);
        }

        [Test]
        public void Dequeue_OnEmptyQueue_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.queue.Dequeue());
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void Peek_WithMultipleElements_ShouldNotRemoveTheTopElement(int[] expected)
        {
            foreach (var num in expected)
            {
                this.queue.Enqueue(num);
                this.builtInQueue.Enqueue(num);
            }

            Assert.AreEqual(builtInQueue.Peek(), this.queue.Peek());
            Assert.AreEqual(builtInQueue.Peek(), this.queue.Peek());
        }

        [Test]
        public void Peek_WithSingeElement_ShouldNotDecreaseCount()
        {
            Assert.AreEqual(0, this.queue.Count);
            this.queue.Enqueue(10);

            Assert.AreEqual(1, this.queue.Count);

            this.queue.Peek();
            Assert.AreEqual(1, this.queue.Count);
        }

        [Test]
        public void Peek_OnEmptyStack_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.queue.Peek());
        }

        [Test]
        [TestCaseSource(nameof(RandomCollections))]
        public void ToArray_WithMultipleElements_ShouldWorkCorrectly(int[] expected)
        {
            foreach (var num in expected)
            {
                this.queue.Enqueue(num);
            }

            CollectionAssert.AreEqual(expected, this.queue.ToArray());
        }

        [Test]
        public void ToArray_WithEmptyQueue_ShouldReturnEmptyArray()
        {
            CollectionAssert.IsEmpty(this.queue.ToArray());
        }

        [Test]
        public void Queue_ContainsThreePrivateFields()
        {
            var queueType = typeof(CircularQueue<sbyte>);
            var allFields = queueType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                .Where(f => f.GetCustomAttribute<CompilerGeneratedAttribute>() == null).ToList();

            Assert.AreEqual(3, allFields.Count, "CircularQueue should have only 3 fields");

            var arrays = allFields.Where(f => f.FieldType.IsArray).ToList();
            var ints = allFields.Where(f => f.FieldType == typeof(int)).ToList();

            Assert.AreEqual(1, arrays.Count, "CircularQueue should have an array field");
            Assert.AreEqual(2, ints.Count, "CircularQueue should have 2 integer fields");
        }

        [Test]
        public void Queue_ContainsSinglePublicProperty_WhichIsCount()
        {
            var queueType = typeof(CircularQueue<sbyte>);
            var allFields = queueType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                .Where(f => f.GetCustomAttribute<CompilerGeneratedAttribute>() != null).ToList();

            Assert.AreEqual(1, allFields.Count, "FastQueue should have only 1 property");

            var arrays = allFields.Where(f => f.FieldType == typeof(int) && f.Name.Contains("Count")).ToList();

            Assert.AreEqual(1, arrays.Count, "FastQueue' property should be called count");
        }
    }
}