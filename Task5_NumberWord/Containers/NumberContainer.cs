using System.Collections;
using System.Collections.Generic;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Containers
{
    public class NumberCollection : INumberContainer
    {
        public List<Number> PartsNumber { get; private set; }

        public int Length => PartsNumber.Count;

        public Number this[int i] => PartsNumber[i];

        public NumberCollection(string number)
        {
            PartsNumber = new List<Number>();
            Init(number);
        }

        private void Init(string number)
        {
            int particleSize = 3;
            int higher = number.Length % particleSize;
            int capacity = number.Length / particleSize;
            int counter = 0;
            int position = 0;

            if (higher > 0)
            {
                capacity++;
                AddToCollection(number, higher, position, counter, capacity);
                position = higher;
                counter++;
            }

            do
            {
                AddToCollection(number, particleSize, position, counter, capacity);
                position += particleSize;
                counter++;

            } while (position < number.Length);
        }

        private void AddToCollection(string number, int higher, int position, int counter, int capacity)
        {
            var part = new Number()
            {
                Value = number.Substring(position, higher),
                Position = capacity - counter - 1
            };

            PartsNumber.Add(part);
        }

        public IEnumerator GetEnumerator()
        {
           yield return PartsNumber.GetEnumerator();
        }
    }
}