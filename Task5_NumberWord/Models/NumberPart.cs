namespace Task5_NumberWord.Models
{
    public class NumberPart
    {
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }

        public NumberPart(string first, string second, string third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
}