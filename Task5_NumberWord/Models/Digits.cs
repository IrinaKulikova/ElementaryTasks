namespace Task5_NumberWord.Models
{
    public class Digits
    {
        public string First { get; private set; }
        public string Second { get; private set; }
        public string Third { get; private set; }

        public Digits(string first, string second, string third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
}