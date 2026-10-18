using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomGenericStack
{
    public class GenericStack<T> : IEnumerable<T>
    {
        private T[] items;
        private int version;

        public GenericStack()
        {
            this.items = Array.Empty<T>();
            this.Count = 0;
            this.version = 0;
        }

        public GenericStack(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be negative.");
            }

            this.items = new T[capacity];
            this.Count = 0;
            this.version = 0;
        }

        public GenericStack(IEnumerable<T>? collection)
        {
            ArgumentNullException.ThrowIfNull(collection);

            this.items = Array.Empty<T>();
            this.Count = 0;
            this.version = 0;

            foreach (T item in collection)
            {
                this.Push(item);
            }
        }

        public int Count { get; private set; }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            this.version++;
            T item = this.items[--this.Count];
            this.items[this.Count] = default!;
            return item;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return this.items[this.Count - 1];
        }

        public void Push(T item)
        {
            if (this.Count == this.items.Length)
            {
                int newCapacity = this.items.Length == 0 ? 4 : this.items.Length * 2;
                T[] newItems = new T[newCapacity];
                Array.Copy(this.items, newItems, this.Count);
                this.items = newItems;
            }

            this.items[this.Count++] = item;
            this.version++;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                result[i] = this.items[this.Count - 1 - i];
            }

            return result;
        }

        public bool Contains(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < this.Count; i++)
            {
                if (comparer.Equals(this.items[i], item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            Array.Clear(this.items, 0, this.Count);
            this.Count = 0;
            this.version++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentVersion = this.version;

            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.version != currentVersion)
                {
                    throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
                }

                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
