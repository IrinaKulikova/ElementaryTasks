using System.Collections.Generic;

namespace CustomCollections
{
    public interface IArgumentCollection<T> : IEnumerable<T>
    {
        int Count { get; }
        int Capacity { get; }
        T this[int index] { get; set; }
        void Add(T item);
        void Clear();
    }
}
