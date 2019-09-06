namespace Task5_NumberWord.Models
{
    public class NumberPart
    {
        public string Value { get; private set; }
        public int Position { get; private set; }

        public NumberPart(string value, int position)
        {
            this.Position = position;
            this.Value = value;
        }
    }
}
