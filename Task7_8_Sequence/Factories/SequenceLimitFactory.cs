using System;
using Task7_8_Sequence.Models;

namespace Task7_8_Sequence.Factories
{
    public class SequenceLimitFactory : ISequenceLimitFactory
    {
        public ISequenceLimit Create(string[] limits)
        {
            int min = 0;
            int max = 0;

            Int32.TryParse(limits[0], out min);

            if (limits.Length > 1)
            {
                Int32.TryParse(limits[1], out max);
            }

            return (min < max) ? new SequenceLimit(min, max) :
                                 new SequenceLimit(max, min);
        }
    }
}
