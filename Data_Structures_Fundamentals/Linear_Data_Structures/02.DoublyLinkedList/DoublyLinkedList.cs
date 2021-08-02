namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item, null, null);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                Count++;
                return;
            }

            var oldHead = this.head;
            oldHead.Previous = newNode;
            this.head = newNode;
            this.head.Next = oldHead;
            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item, null, null);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                Count++;
                return;
            }

            var oldTail = tail;
            oldTail.Next = newNode;
            newNode.Previous = oldTail;
            this.tail = newNode;
            Count++;
        }

        public T GetFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            return this.head.Item;
        }

        public T GetLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            var oldHead = this.head;
            this.head = this.head.Next;
            Count--;
            return oldHead.Item;
        }

        public T RemoveLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            var oldTail = this.tail;
            this.tail = this.tail.Previous;
            Count--;

            return oldTail.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}