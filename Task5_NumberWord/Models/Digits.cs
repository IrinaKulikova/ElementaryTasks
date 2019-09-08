namespace Task5_NumberWord.Models
{
    public class Digits
    {
        #region private fields

        private readonly string _first;
        private readonly string _second;
        private readonly string _third;

        #endregion

        #region properties

        public string First { get => _first; }
        public string Second { get => _second; }
        public string Third { get => _third; }

        #endregion

        public Digits(string first, string second, string third)
        {
            _first = first;
            _second = second;
            _third = third;
        }
    }
}