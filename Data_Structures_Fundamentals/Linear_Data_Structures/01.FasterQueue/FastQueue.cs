﻿namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public FastQueue()
        {

        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> current = this.head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            var oldHead = this.head;
            this.head = this.head.Next;
            this.Count--;
            return oldHead.Item;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item, null);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
                this.Count++;
                return;
            }

            this.tail.Next = newNode;
            this.tail = this.tail.Next;
            this.Count++;

        }

        public T Peek()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            return this.head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}