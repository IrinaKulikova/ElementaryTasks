namespace Task8_Fibonacci.Models
{
    public class SequenceLimit : ISequenceLimit
    {
        #region private fields

        private readonly int _min;
        private readonly int _max;

        #endregion

        #region properties

        public int Min { get => _min; }

        public int Max { get => _max; }

        #endregion

        public SequenceLimit(int min, int max)
        {
            _min = min;
            _max = max;
        }
    }
}
