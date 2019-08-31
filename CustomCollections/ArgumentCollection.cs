using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomCollections
{
    public class ArgumentCollection<T> : IArgumentCollection<T>
    {
        private int _count = 0;
        int _capacity = 4;
        private T[] _arguments;

        public int Count => _count;

        public int Capacity
        {
            get => _capacity;
            set
            {
                _capacity = value;
                Array.Resize(ref _arguments, _capacity);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _count)
                {
                    return _arguments[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (index >= 0 && index < _count)
                {
                    _arguments[index] = value;
                }
                else if (index == _count)
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
            if (Count >= _arguments.Length)
            {
                Array.Resize(ref _arguments, (int)1.5 * _arguments.Length);
            }
            _arguments[_count++] = item;
        }

        public void Clear()
        {
            Array.Clear(_arguments, 0, Count);
            _count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= Count; i++)
            {
                yield return _arguments[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ArgumentCollection()
        {
            _arguments = new T[_capacity];
        }

        public ArgumentCollection(int capacity) : this()
        {
            this.Capacity = capacity;
        }
    }
}

