using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomCollections
{
    public class ArgumentCollection<T> : IArgumentCollection<T>
    {
        private int count = 0;
        int capacity = 4;
        private T[] arguments;

        public int Count => count;

        public int Capacity
        {
            get => capacity;
            set
            {
                capacity = value;
                Array.Resize(ref arguments, capacity);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                {
                    return arguments[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (index >= 0 && index < count)
                {
                    arguments[index] = value;
                }
                else if (index == count)
                {
                    Add(value);
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void Add(T item)
        {
            if (Count >= arguments.Length)
            {
                Array.Resize(ref arguments, (int)1.5 * arguments.Length);
            }
            arguments[count++] = item;
        }

        public void Clear()
        {
            Array.Clear(arguments, 0, Count);
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= Count; i++)
            {
                yield return arguments[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ArgumentCollection()
        {
            arguments = new T[capacity];
        }

        public ArgumentCollection(int capacity) : this()
        {
            this.Capacity = capacity;
        }

        public ArgumentCollection(T[] args)
        {
            arguments = new T[capacity];

            for (int i = 0; i < arguments.Length; i++)
            {
                Add(args[i]);
            }
        }
    }
}

