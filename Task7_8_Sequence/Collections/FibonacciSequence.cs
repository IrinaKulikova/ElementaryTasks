using System.Collections;
using System.Collections.Generic;
using Task7_8_Sequence.Models;

namespace Task7_8_Sequence.Collections
{
    public class FibonacciSequence : IEnumerable<int>
    {
        private readonly List<int> _sequence;
        private readonly ISequenceLimit _sequenceLimits;

        public FibonacciSequence(ISequenceLimit sequenceLimit)
        {
            _sequenceLimits = sequenceLimit;
            _sequence = new List<int>();

            int f0 = 1;
            int f1 = 1;

            Init(f0, f1);
        }

        private void Init(int f0, int f1)
        {
            if (f0 > _sequenceLimits.Max)
            {
                return;
            }

            if (f0 >= _sequenceLimits.Min)
            {
                _sequence.Add(f0);
            }

            Init(f1, f0 + f1);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _sequence.Count; i++)
            {
                yield return _sequence[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
