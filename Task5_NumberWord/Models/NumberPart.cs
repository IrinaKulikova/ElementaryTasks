namespace Task5_NumberWord.Models
{
    public class NumberPart
    {
        #region private fields

        private readonly string _value;
        private readonly int _position;

        #endregion

        #region prperties

        public string Value { get => _value; }
        public int Position { get => _position; }

        #endregion

        public NumberPart(string value, int position)
        {
            _position = position;
            _value = value;
        }
    }
}
