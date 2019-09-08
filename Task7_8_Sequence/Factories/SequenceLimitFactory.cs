using System;
using Task8_Fibonacci.Models;

namespace Task8_Fibonacci.Factories
{
    class SequenceLimitFactory : ISequenceLimitFactory
    {
        public ISequenceLimit Create(string[] limits)
        {
            int min = 0;
            int max = 0;

            Int32.TryParse(limits[0], out min);
            Int32.TryParse(limits[1], out max);

            return (min < max) ? new SequenceLimit(min, max) :
                                 new SequenceLimit(max, min);
        }
    }
}
