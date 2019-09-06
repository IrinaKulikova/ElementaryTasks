using Task5_NumberWord.Enums;

namespace Task5_NumberWord.Models
{
    public class Arguments
    {
        #region properties

        public string Number { get; private set; }
        public Language Language { get; private set; }

        #endregion

        public Arguments(string number, Language language)
        {
            Number = number;
            Language = language;
        }

        public Arguments(string number) : this(number, Language.EU) { }
    }
}
