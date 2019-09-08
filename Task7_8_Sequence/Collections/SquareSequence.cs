using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Task8_Fibonacci.Models;

namespace Task8_Fibonacci.Collections
{
    public class SquareSequence : IEnumerable<int>
    {
        private readonly List<int> _sequence;
        private readonly ISequenceLimit _sequenceLimits;

        public SquareSequence(ISequenceLimit sequenceLimit)
        {
            _sequenceLimits = sequenceLimit;
            _sequence = new List<int>();

            int limitMin = (int)Math.Sqrt(sequenceLimit.Min) + 1;
            int limitMax = (int)Math.Sqrt(sequenceLimit.Max);

            _sequence.AddRange(Enumerable.Range(limitMin, limitMax - limitMin));
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
