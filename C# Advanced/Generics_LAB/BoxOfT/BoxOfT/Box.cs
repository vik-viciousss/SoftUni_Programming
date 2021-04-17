using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T element)
        {
            data.Add(element);
        }

        public T Remove()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove from empty collection!");
            }

            T element = this.data.LastOrDefault();
            this.data.RemoveAt(Count - 1);

            return element;
        }
    }
}
