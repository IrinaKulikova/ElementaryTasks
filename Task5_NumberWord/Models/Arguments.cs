using Task5_NumberWord.Enums;

namespace Task5_NumberWord.Models
{
    public class Arguments
    {
        public string Number { get; set; }
        public Language Language { get; set; }

        public Arguments(string number, Language language)
        {
            Number = number;
            Language = language;
        }
    }
}
