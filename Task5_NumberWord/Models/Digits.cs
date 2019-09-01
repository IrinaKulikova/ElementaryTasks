namespace Task5_NumberWord.Models
{
    public class Digits
    {
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }

        public Digits(string first, string second, string third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
}